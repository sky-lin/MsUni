﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MsUni.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ms University";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Board Member";

            return View();
        }
    }
}