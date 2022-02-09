using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolsAppSPA_BE.Dtos
{
    public class ViewSchool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ViewStudent> Students { get; set; }
    }
}
