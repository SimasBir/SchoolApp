using Microsoft.EntityFrameworkCore;
using SchoolsAppSPA_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolsAppSPA_BE.Data
{
    public class DataContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
