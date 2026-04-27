using System;

namespace Healthcare_Platform.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}
