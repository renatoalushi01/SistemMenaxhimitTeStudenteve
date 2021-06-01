using AutoMapper;
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
using System.Security.Claims;
using System.Threading.Tasks;

namespace SistemMenaxhimitTeStudenteve.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        public StudentsController(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;

            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var students = await _studentServices.GetAllStudents();
            ViewBag.StartIndex = 0;
            return View(students);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Create()
        {

            return View();
        }

        // POST: StudentsController/Create
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

            return View(model);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
