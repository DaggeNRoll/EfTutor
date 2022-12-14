using EfTutor.Entities;
using System;
using System.Collections.Generic;
/*using System.Data.Entity;*/
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfTutor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new Context())
            {
                /*var dep1 = new Department()
                {
                    Name = "HR"
                };

                var dep2 = new Department()
                {
                    Name = "Tech"
                };

                var address1 = new Address()
                {
                    Country = "Russia",
                    City = "Moscow",
                    PostalCode = 22869,
                    Street = "800-letiya Moscvy",
                };

                var address2 = new Address()
                {
                    Country = "Russia",
                    City = "Moscow",
                    PostalCode = 228178,
                    Street = "Pupkina podzalupkina",
                };

                var role1 = new Role()
                {
                    Name = "Head",
                };

                var role2 = new Role()
                {
                    Name = "Junior",
                };

                var person1 = new Person()
                {
                    Name = "Maria",
                    Surename = "Trufanova",
                    Department = dep1,
                    Address = address1,
                    Roles = new List<Role>() { role1, role2 },
                };
                var person2 = new Person()
                {
                    Name = "Nikolay",
                    Surename = "Smirnov",
                    Department = dep2,
                    Address = address2,
                    Roles = new List<Role>() { role2 },
                };





                context.Add(person1);
                context.Add(person2);
                context.SaveChanges();*/

                var persons = context.Persons.Include(p => p.Address).Include(p=>p.Roles);

                /*
                 Ещё можно с помощью IQueryable и LINQ Query Syntax (тупо sql запрос)
                 */

                foreach (var person in persons)
                {
                    person.Name += "1";
                    Console.WriteLine($"{person.Name} {person.Surename} {person.Address.Country} {person.Address.Street} ");
                    foreach (var role in person.Roles)
                    {
                        Console.WriteLine(role.Name);
                    }
                }
                context.SaveChanges();//UPDATE  


                //удаление из бд
                var personToDelete = context.Persons.Where(p => p.Name.Contains("Maria")).FirstOrDefault();
                
                if(personToDelete!= null) { context.Persons.Remove(personToDelete); }
                
                context.SaveChanges();

            }
        }
    }
}
