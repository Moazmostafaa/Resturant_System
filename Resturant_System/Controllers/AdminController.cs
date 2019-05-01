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
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["Id"]);
            if (id == null || Session["Id"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var items = db.Items.Include(i => i.category);
                return View(items.ToList());
            }   
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            int id = Convert.ToInt32(Session["Id"]);
            if (id == null || Session["Id"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name");
                return View();
            }
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Items items)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", items.CategoryID);
            return View(items);
        }
        
        
        //GET: Admin/DeleteUser/id
        public ActionResult DeleteUser(int id)
        {
            int ids = Convert.ToInt32(Session["Id"]);
            if (ids == null || Session["Id"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                User user = db.Users.Single(x => x.Id == id);
                db.Users.Remove(user);
                db.SaveChanges();
                return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
            }
        }
        
        //GET: Admin/BlockUser/id
        public ActionResult BlockUser(int id)
        {
            int ids = Convert.ToInt32(Session["Id"]);
            if (ids == null || Session["Id"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                User user = db.Users.Single(x => x.Id == id);
                user.blocked = false;
                db.SaveChanges();
                return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
            }
        }
        //GET: Admin/UnBlockUser/id
        public ActionResult UnBlockUser(int id)
        {
            int ids = Convert.ToInt32(Session["Id"]);
            if (ids == null || Session["Id"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                User user = db.Users.Single(x => x.Id == id);
                user.blocked = true;
                db.SaveChanges();
                return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
            }
        }
         public ActionResult Edit(int? id)
        {
            int ids = Convert.ToInt32(Session["Id"]);
            if (ids == null || Session["Id"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Items items = db.Items.Find(id);
                if (items == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", items.CategoryID);
                return View(items);
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Items items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "Name", items.CategoryID);
            return View(items);
        }

        
    }
}
