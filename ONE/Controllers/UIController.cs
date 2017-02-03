using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONE.Controllers
{
    public class UIController : Controller
    {
        public ActionResult Login() {

            return View();
        }

        public ActionResult Register() {
            return View();
        }

        // GET: UI
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _Student() {

            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _Subject()
        {

            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _StudentSubject()
        {
            return PartialView();
        }
    }
}