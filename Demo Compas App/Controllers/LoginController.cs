using Demo_Compas_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public ActionResult autherize(Demo_Compas_App.Models.UserMaster usermodel)
        {
            using (ProjectMasterEntities db = new ProjectMasterEntities())

            {
                var userDetails = db.UserMasters.Where(x => x.UserName == usermodel.UserName && x.UserPassword == usermodel.UserPassword).FirstOrDefault();
                if (userDetails == null)
                {
                   // usermodel.Loginerror = "Wrong User Name or password";
                    return View("Index", usermodel);
                }
                else
                {
                    Session["Name"] = userDetails.UserName;
                    Session["UserId"] = userDetails.UserId;
                    // find the role of user

                    using (var context = new ProjectMasterEntities())
                    {
                        int? roleid = userDetails.RoleId;
                        var clientIdParameter = new SqlParameter("@RoleId",roleid);

                        var result = context.Database
                            .SqlQuery<usp_getMenuNameRoleWise_Result>("usp_getMenuNameRoleWise @RoleId", clientIdParameter)
                            .ToList();
                        Session["UserMenu"] = result;
                    }
















                    //List<usp_getMenuNameRoleWise_Result> objmm = new List<usp_getMenuNameRoleWise_Result>();
                    //int? roleid = userDetails.RoleId;
                    // objmm = db.usp_getMenuNameRoleWise(roleid);

                    // find the list of all the available menus for the users role - store in session
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult Logout()
        {
            int userid = (int)Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
