using System;
using System.Linq;
using System.Web.Mvc;
using Healthcare_Platform.Models;

public class AppointmentController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult MyAppointments()
    {
        int userId = (int)Session["UserId"];

        var appointments = db.Appointments
            .Where(a => a.PatientId == userId)
            .Join(db.Doctors,
                  a => a.DoctorId,
                  d => d.Id,
                  (a, d) => new AppointmentViewModel
                  {
                      Id = a.Id,
                      DateTime = a.DateTime,
                      Status = a.Status,
                      DoctorName = d.Specialization
                  })
            .ToList();

        return View(appointments);
    }



    public ActionResult Book(int doctorId)
    {
        if (Session["UserId"] == null)
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.DoctorId = doctorId;
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Book(int doctorId, DateTime dateTime)
    {
        if (Session["UserId"] == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var appointment = new Appointment
        {
            PatientId = Convert.ToInt32(Session["UserId"]),
            DoctorId = doctorId,
            DateTime = dateTime,
            Status = "Booked"
        };

        db.Appointments.Add(appointment);
        db.SaveChanges();

        TempData["Message"] = "Reminder: Your appointment has been booked!";

        return RedirectToAction("MyAppointments");
    }



    public ActionResult Cancel(int id)
    {
        var appt = db.Appointments.Find(id);
        appt.Status = "Cancelled";
        db.SaveChanges();

        return RedirectToAction("MyAppointments");
    }

    public ActionResult Calendar()
    {
        if (Session["UserId"] == null)
        {
            return RedirectToAction("Login", "Account");
        }

        int userId = (int)Session["UserId"];

        var appointments = db.Appointments
            .Where(a => a.PatientId == userId)
            .OrderBy(a => a.DateTime)
            .ToList();

        return View(appointments);
    }

}
