﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("http://localhost:49036/Pages/default.html");
        }
    }
}
