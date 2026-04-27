using System;

namespace Healthcare_Platform.Models
{
    public class DoctorAppointmentViewModel
    {
        public string PatientName { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}
