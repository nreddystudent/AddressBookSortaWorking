﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactBook.Controllers
{ 
        public class HomeController : Controller
        {
            // GET: Home
            [Authorize]
            public ActionResult Index()
            {
            ViewBag.Status = UserController.globalUID;
                return View();
            }
        }
}