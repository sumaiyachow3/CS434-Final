using System.Linq;
using System.Web.Mvc;
using Healthcare_Platform.Models;

namespace Healthcare_Platform.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private bool IsAdmin()
        {
            return Session["Role"] != null && Session["Role"].ToString() == "Admin";
        }

        private void PopulateUsersDropdown()
        {
            ViewBag.Users = new SelectList(db.Users.ToList(), "Id", "Email");
        }

        public ActionResult Index()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        public ActionResult Users()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var users = db.Users.ToList();
            return View(users);
        }

        public ActionResult Doctors()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var doctors = db.Doctors.ToList();
            return View(doctors);
        }

        public ActionResult AddDoctor()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            PopulateUsersDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult AddDoctor(Doctor doctor)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var userExists = db.Users.Any(u => u.Id == doctor.UserId);
            if (!userExists)
            {
                ViewBag.Error = "Selected user does not exist.";
                PopulateUsersDropdown();
                return View(doctor);
            }

            var alreadyDoctor = db.Doctors.Any(d => d.UserId == doctor.UserId);
            if (alreadyDoctor)
            {
                ViewBag.Error = "This user is already registered as a doctor.";
                PopulateUsersDropdown();
                return View(doctor);
            }

            db.Doctors.Add(doctor);
            db.SaveChanges();
            return RedirectToAction("Doctors");
        }

        public ActionResult DeleteDoctor(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var doctor = db.Doctors.Find(id);
            if (doctor == null) return RedirectToAction("Doctors");
            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Doctors");
        }
    }
}