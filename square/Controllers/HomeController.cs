using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using square.Models;

namespace square.Controllers
{
    
    public class HomeController : Controller
    {
        Database1Entities db = new Database1Entities();

       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [Authorize]
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignupConfirm(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult form()
        {
            ViewBag.Message = "Your form page.";

            return View(db.Users.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult update(int id)
        {
            ViewBag.Message = "Your form page.";
            User u = db.Users.Find(id);
            return View(u);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult updateConfirm(int id)
        {
            User u = db.Users.Find(id);
            ViewBag.Message = "Your form page.";
            String name = Request["Name"];
            String email = Request["Email"];
            String pass = Request["Password"];

            u.Name = name;
            u.Email = email;
            u.Password = pass;

            db.SaveChanges();

            return RedirectToAction("form");
        }

        [Authorize (Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ViewBag.Message = "Your form page.";
            User u = db.Users.Find(id);
            db.Users.Remove(u);
            db.SaveChanges();

            return RedirectToAction("form");
        }
    }
}