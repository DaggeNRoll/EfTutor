using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/*using System.Linq;*/
using System.Text;
using System.Threading.Tasks;

namespace EfTutor.Entities
{
    [Table("Deps")]
    internal class Department
    {
        [Key]
        public int Id2 { get; set; }
        public ICollection<Person> Persons { get; set; }
        [Required]
        public string Name { get; set; }

        /*[NotMapped]
        public int NotMapped { get; set; }*/
    }
}
