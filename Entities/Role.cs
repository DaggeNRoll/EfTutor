using System;
using System.Collections.Generic;
/*using System.Linq;*/
using System.Text;
using System.Threading.Tasks;

namespace EfTutor.Entities
{
    internal class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
