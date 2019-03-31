using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Resturant_System.Models;

namespace Resturant_System.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["Id"]);
            if (id == null || Session["Id"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Order order =new Order();
                order.user_id = id;
                db.SaveChanges();
                var items = db.Items.Include(i => i.category);
                return View(items.ToList());
            }
        }
                       
        // GET: User/Edit/5
        [HttpGet]
        public ActionResult EditProfile()
        {
            int id = Convert.ToInt32(Session["Id"]);
            if (id == null || Session["Id"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
           
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(User user)
        {
            if (ModelState.IsValid)
            {
                user.blocked = true;
                user.TyperID = 2;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { result = 1 });
            }
            return View();
        }
    }
}
