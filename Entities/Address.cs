using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfTutor.Entities
{
    internal class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Street { get; set; }

        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
