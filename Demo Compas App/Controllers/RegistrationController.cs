using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Compas_App.Models;

namespace Demo_Compas_App.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult AddorEdit(int id=0)
        {
            User_Reg userModel = new User_Reg();
            return View(userModel);
        }


        [HttpPost]
        public ActionResult AddorEdit(User_Reg userModel)
        {
            using (TestEntitiesRegistration dbModel= new TestEntitiesRegistration())
                
              {
                if (dbModel.User_Reg.Any(x => x.UserName == userModel.UserName))
                {

                    //ViewBag.Dmessage = "User name already Exit ";
                    // return View("AddorEdit", userModel);

                   TempData["AlertMessage"] = "User already Exit";
                    return View("AddorEdit", userModel);
                }

                dbModel.User_Reg.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();

            //ViewBag.SuccessMessage = "Register User Sucessfully";
            TempData["AlertMessage2"] = "Register User Sucessfully";
            return View("AddorEdit", new User_Reg());  
        }

    }
}