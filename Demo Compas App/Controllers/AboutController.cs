using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Compas_App.Models;

namespace Demo_Compas_App.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            TomatoProductInfo userModel = new TomatoProductInfo();
            return View(userModel);
        }


        [HttpPost]
        public ActionResult Create(TomatoProductInfo userModel)
        {

            using (TomatoProduct dbModel = new TomatoProduct())
            {
                dbModel.TomatoProductInfoes.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            TempData["AlertMessage2"] = "Product Add Sucessfully";
            return View("Create",new TomatoProductInfo());
           
        }



    }
}