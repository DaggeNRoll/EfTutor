using EfTutor.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
/*using System.Linq;*/
using System.Text;
using System.Threading.Tasks;

namespace EfTutor
{
    internal class Context: DbContext
    {
        public Context() 
        {
           /* Database.EnsureDeleted();
            Database.EnsureCreated();*/
           Database.Migrate();//автоматом накатить миграцию при запуске
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=db;username=postgres;password=Vhhvze05042002")
                .LogTo(Console.WriteLine);//логгирование
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne<Department>(p => p.Department)
                .WithMany(d => d.Persons)
                .HasForeignKey(p => p.CurrentDepartmentId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address).WithOne(a => a.Person);
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Roles).WithMany(r => r.Persons)
                .UsingEntity(j => j.ToTable("PersonToRole"));

            modelBuilder.Entity<Person>().HasData(new
            Person
            {
                Id= 1,
                Name="Vasya",
                Surename="Pupkin",
                CurrentDepartmentId=1,
                Age=17,

            });//не забыть Add-migration и дать айдишник, даже если он auto

            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
