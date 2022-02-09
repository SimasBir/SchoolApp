using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolsAppSPA_BE.Models
{
    public class Student : NamedEntity
    {
        public School School { get; set; }
        public int SchoolId { get; set; }
    }
}
