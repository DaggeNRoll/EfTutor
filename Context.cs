﻿using EfTutor.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfTutor
{
    internal class Context: DbContext
    {
        public Context() 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=db;username=postgres;password=Vhhvze05042002");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne<Department>(p => p.Department)
                .WithMany(d => d.Persons)
                .HasForeignKey(p => p.CurrentDepartmentId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address).WithOne(a => a.Person);

            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Partner> Partners { get; set; }
    }
}
