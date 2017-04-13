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
        public ActionResult autherize(Demo_Compas_App.Models.User_Reg usermodel)
        {
            using (TestEntitiesRegistration db = new TestEntitiesRegistration())

            {
                //int isadmin= Convert.ToInt32(db.User_Reg.Where(y=>y.IsAdmin==usermodel.IsAdmin).First());
               // if(isadmin==0)
                //{
                   // usermodel.Loginerror = "Not Valid User";
                   // return View("Index", usermodel);
                //}
                

                var userDetails = db.User_Reg.Where(x => x.UserName == usermodel.UserName && x.Password == usermodel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    usermodel.Loginerror = "Wrong User Name or password";
                    return View("Index", usermodel);
                }
                else
                {
                    Session["Name"] = userDetails.UserName;
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