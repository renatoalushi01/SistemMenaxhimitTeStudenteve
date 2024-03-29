﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemMenaxhimitTeStudenteve.Models;
using SistemMenaxhimitTeStudenteve.Services;
using SistemMenaxhimitTeStudenteve.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemMenaxhimitTeStudenteve.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        private readonly ILendetService _lendService;
        private readonly IStudentLendService _studentLendService;
        public StudentsController(IStudentServices studentServices, IMapper mapper ,
            ILendetService lendetService,
            IStudentLendService studentLendService)
        {
            _studentServices = studentServices;
            _mapper = mapper;
            _lendService = lendetService;
            _studentLendService = studentLendService;
        }

        [Authorize]
        public async Task<IActionResult> Index(int page = 0 ,int pageSize = 5)
        {
            var students = await _studentServices.GetAllStudents(page,pageSize);
            ViewBag.Startindex = 1;
            var total = students.CountTotal;
            ViewData["total"] = total;
            ViewData["RowPerPage"] = students.Count;
            ViewBag.Totalnumber = students.TotalPages;
            return View(students);
        }
        [Authorize]
        public async Task<JsonResult> GetLendPerStudent(int? studentId)
        {
            if (studentId == null)
            {
                return new JsonResult(new { });
            }

            var result = await _studentLendService.GetAllLendStudent(Convert.ToInt32(studentId));
            var total = result.Where(x => x.Subscribe).Select(x => x.LendId).Count();
            return new JsonResult( new{result = total});
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var model = new StudentDetails();
            model.Student = await _studentServices.GetAsync(Convert.ToInt32(id));
            model.StudentLends = await _studentLendService.GetStudentLends(Convert.ToInt32(id));
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterStudent model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var exist = await _studentServices.CheckIfStudentExist(model.NID);
            if (!exist)
            {
                ViewData["Error"] = "Ju ekzistoni i rregjistruar ne rregjistrin e studenteve! ";
                return View(model);
            }
            var student = _mapper.Map<Student>(model);
            var hash = BCrypt.Net.BCrypt.HashPassword(student.Fjalkalimi);
            student.Fjalkalimi = hash;
            await _studentServices.AddAsync(student);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginStudent model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var exist = await _studentServices.CheckIfStudentExist(model.NID);
            if (exist)
            {
                ViewData["Error"] = "Ju nuk ekzistoni i rregjistruar ne rregjistrin e studenteve! ";
                return View(model);
            }

            var student = await _studentServices.GetStudent(model.NID);
            var result = BCrypt.Net.BCrypt.Verify(model.Fjalkalimi, student.Fjalkalimi);
            if (result)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.NID),
                    new Claim("StudentNID", model.NID),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.MeMbajMend
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),authProperties);
                return RedirectToAction("Index");
            }
            ViewData["Feild"] = "Ju litemi vendosni sakt te dhenat e identifikimit! ";
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentServices.GetStudentForEdit(Convert.ToInt32(id));
            var model = _mapper.Map<EditStudent>(student);
            model.Lendet = await _lendService.GetAll();
            var previousData = await _studentLendService.GetAllLendStudent(model.Id);
            if (previousData.Count != 0)
            {
                model.StudentLends = previousData;
            }
            return View(model);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditStudent model)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            var previousData = await _studentLendService.GetAllLendStudent(model.Id);
            if (previousData != null)
            {
                foreach (var item in model.StudentLends)
                {
                    item.Id = previousData.Where(x => x.LendId == item.LendId).Select(x => x.Id).FirstOrDefault();
                    item.Data = DateTime.Now;
                    await _studentLendService.UpdateAsync(item);
                }
            }
            else
            {
                foreach (var item in model.StudentLends)
                {
                    item.Data = DateTime.Now;
                    await _studentLendService.AddAsync(item);
                }
            }
            
            var student = _mapper.Map<Student>(model);
            await _studentServices.UpdateAsync(student);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = "Studenti nuk u fshi";
                return RedirectToAction("Index");
            }

            await _studentServices.DeleteAsync(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }

    }
}
