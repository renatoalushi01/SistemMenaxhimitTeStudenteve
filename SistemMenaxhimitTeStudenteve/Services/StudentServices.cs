using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Models;
using SistemMenaxhimitTeStudenteve.Repository.Commin;

namespace SistemMenaxhimitTeStudenteve.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly StudentRepository _studentRepository;

        public StudentServices(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task AddAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
        }

        public async Task<Student> GetAsync(int id)
        {
            return await _studentRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentRepository.RemoveAsync(id);
        }

        public async Task<bool> CheckIfStudentExist(string nId)
        {
            return await _studentRepository.CheckIfExist(nId);
        }

        public async Task<Student> GetStudent(string nId)
        {
            return await _studentRepository.GetIfExist(nId);
        }

        public async Task<Student> GetStudentForEdit(int id)
        {
            return await _studentRepository.GetStudentForEdit(id);
        }
    }
}
