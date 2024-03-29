﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<StudentLend> StudentLends { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Lendet>().HasData(new Lendet
            {
                Id=1,
                Emer = "Lenda1",
                Info = "Test Test"
            });
            builder.Entity<Lendet>().HasData(new Lendet
            {
                Id = 2,
                Emer = "Lenda2",
                Info = "Test Test"
            });
            builder.Entity<Lendet>().HasData(new Lendet
            {
                Id = 3,
                Emer = "Lenda3",
                Info = "Test Test"
            });
            builder.Entity<Lendet>().HasData(new Lendet
            {
                Id = 4,
                Emer = "Lenda4",
                Info = "Test Test"
            });
        }
    }
}
