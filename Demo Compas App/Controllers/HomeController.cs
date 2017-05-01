using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Compas_App.Models;

namespace Demo_Compas_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Information()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}