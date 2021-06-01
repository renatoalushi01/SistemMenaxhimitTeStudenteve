using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Models;
using SistemMenaxhimitTeStudenteve.Repository.Commin;

namespace SistemMenaxhimitTeStudenteve.Services
{
    public class LendetService : ILendetService
    {
        private readonly LendetRepository _lendetRepository;

        public LendetService(LendetRepository lendetRepository)
        {
            _lendetRepository = lendetRepository;
        }

        public async Task<IEnumerable<Lendet>> GetAll()
        {
            return await _lendetRepository.GetAll();
        }

        public async Task AddAsync(Lendet lendet)
        {
            await _lendetRepository.AddAsync(lendet);
        }

        public async Task<Lendet> GetAsync(int id)
        {
            return await _lendetRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Lendet lendet)
        {
            await _lendetRepository.UpdateAsync(lendet);
        }

        public async Task DeleteAsync(int id)
        {
            await _lendetRepository.RemoveAsync(id);
        }
    }
}
