using Microsoft.EntityFrameworkCore;
using SistemMenaxhimitTeStudenteve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemMenaxhimitTeStudenteve.Repository.Extensions
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; }
        public int TotalPages { get; }
        public int CountTotal { get; }

        private PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            int index = (pageIndex == 0) ? pageIndex = 1 : pageIndex;
            PageIndex = index;
            CountTotal = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public bool HasPreviousPage => (PageIndex > 1);

        public bool HasNextPage => (PageIndex < TotalPages);

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            int index = (pageIndex == 0) ? pageIndex = 1 : pageIndex;
            var items = await source.Skip((index - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, index, pageSize);
        }

        public static PaginatedList<T> CreateForPricingScheme(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
