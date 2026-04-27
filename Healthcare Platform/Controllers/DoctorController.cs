using System;
using System.Linq;
using System.Web.Mvc;
using Healthcare_Platform.Models;

namespace Healthcare_Platform.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var doctors = db.Doctors.ToList();
            return View(doctors);
        }

        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int doctorId = Convert.ToInt32(Session["UserId"]);

            var appointments = db.Appointments
                .Where(a => a.DoctorId == doctorId)
                .Join(db.Users,
                      a => a.PatientId,
                      u => u.Id,
                      (a, u) => new DoctorAppointmentViewModel
                      {
                          PatientName = u.Email, // or u.Email if no Name field
                          DateTime = a.DateTime,
                          Status = a.Status
                      })
                .ToList();

            return View(appointments);
        }
    }
}
