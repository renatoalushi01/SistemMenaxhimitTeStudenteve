using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Models;
using SistemMenaxhimitTeStudenteve.Repository.Extensions;

namespace SistemMenaxhimitTeStudenteve.Services
{
    public interface IStudentServices
    {
        Task<PaginatedList<Student>> GetAllStudents(int page, int pageSize);
        Task AddAsync(Student student);
        Task<Student> GetAsync(int id);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<bool> CheckIfStudentExist(string nId);
        Task<Student> GetStudent(string nId);
        Task<Student> GetStudentForEdit(int id);
    }
}
