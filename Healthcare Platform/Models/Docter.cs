using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthcare_Platform.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Specialization { get; set; }
        public string Availability { get; set; }
        public double Rating { get; set; }
    }
}