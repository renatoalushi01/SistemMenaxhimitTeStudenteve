using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Models;

namespace SistemMenaxhimitTeStudenteve.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lendet> Lendet { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Lendet>().HasData(new Lendet
            {
                Id=1,
                Emer = "Lenda1",
            });
            builder.Entity<Lendet>().HasData(new Lendet
            {
                Id = 2,
                Emer = "Lenda2",
            });
            builder.Entity<Lendet>().HasData(new Lendet
            {
                Id = 3,
                Emer = "Lenda3",
            });
            builder.Entity<Lendet>().HasData(new Lendet
            {
                Id = 4,
                Emer = "Lenda4",
            });
        }
    }
}
