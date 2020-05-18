using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolOlympiads.DomainObjects
{
    public class Olympiad : DomainObject
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Type { get; set; }

        public string Class { get; set; }

        public int Year { get; set; } 

    }
}
