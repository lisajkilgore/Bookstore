﻿using Bookstore.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.WebMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        { 
             if (User.Identity.IsAuthenticated)   
            {   
                var user = User.Identity;
        ViewBag.Name = user.Name;   
               
                ViewBag.displayMenu = "No";   
   
                if (IsAdminUser())   
                {   
                    ViewBag.displayMenu = "Yes";   
                }   
                return View();
}   
            else   
            {   
                ViewBag.Name = "Not Logged IN";   
            }   
            return View();   
   
        }

        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}