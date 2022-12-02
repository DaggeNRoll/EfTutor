using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
/*using System.Linq;*/
using System.Text;
using System.Threading.Tasks;

namespace EfTutor.Entities
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public int Age { get; set; }

        public string MiddleName { get; set; }
        public Department Department { get; set; }
        public int CurrentDepartmentId { get; set; }

        
        public Partner Partner { get; set; }
        public Address Address { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
