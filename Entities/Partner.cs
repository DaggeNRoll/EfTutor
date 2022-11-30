﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfTutor.Entities
{
    internal class Partner
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public Person Person { get; set; }
    }
}
