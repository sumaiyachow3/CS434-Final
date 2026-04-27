using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Healthcare_Platform.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("MySqlConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
