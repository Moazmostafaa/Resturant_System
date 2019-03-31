
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resturant_System.Models;

namespace Graduation_Project.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Account

        [HttpGet]
        public ActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.TyperID = 2;
                user.blocked = true;
                db.Users.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.userName + " Successfuly Registered";
                Session["Id"] = user.Id;
                Session["TypeId"] = user.TyperID;

            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //login
        [HttpPost]
        public ActionResult Login(FormCollection user )
        {
            string us = user["username"];
            string pass = user["password"];
                
            var usr = db.Users.Single(u => u.userName == us && u.Password == pass);
            if (usr != null && usr.blocked)
            {
                    Session["Id"] = usr.Id;
                    Session["TyperId"] = usr.TyperID;
                    return RedirectToAction("LoggedIn");
            }
            else
            {
            ModelState.AddModelError("", "Username or password is worng.");

            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Id"] != null)
            {
                if (Convert.ToInt32(Session["TyperId"]) == 2)
                {
                  return  RedirectToAction("EditProfile", "User");
                }
                else if (Convert.ToInt32(Session["TyperId"]) == 1)
                {
                   return RedirectToAction("Index", "Admin");
                }
            }
                return RedirectToAction("login");
        }

        [HttpPost]
        public JsonResult IsAlreadySigned(string Username)
        {
             return Json(!db.Users.Any(u => u.userName == Username), JsonRequestBehavior.AllowGet);
        }


        //logout
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }


    }
}