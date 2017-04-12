using Demo_Compas_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Compas_App.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult autherize(Demo_Compas_App.Models.User_Login usermodel)
        {
            using (TestEntities db = new TestEntities())

            {
               
                var userDetails = db.User_Login.Where(x => x.Name == usermodel.Name && x.Password == usermodel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    usermodel.Loginerror = "Wrong User Name or password";
                    return View("Index", usermodel);
                }
                else
                {
                    Session["Name"] = userDetails.Name;
                    Session["UserId"] = userDetails.UserId;
                    return RedirectToAction("Index", "Home");
                }
            }


        }

        public ActionResult Logout()
        {
            int userid=(int)Session["UserId"];
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }







    }
}