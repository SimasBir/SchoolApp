using System.Collections.Generic;

namespace SchoolsAppSPA_BE.Dtos
{
    public class ViewSchool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ViewStudent> Students { get; set; }
    }
}
