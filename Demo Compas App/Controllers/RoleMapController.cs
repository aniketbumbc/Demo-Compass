using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Compas_App.Models;

namespace Demo_Compas_App.Controllers
{
    public class RoleMapController : Controller
    {
        // GET: RoleMap
        public ActionResult Index()
        {
            List<RoleMaster> objRoleMaster = new List<RoleMaster>();
          ProjectMasterEntities db = new ProjectMasterEntities();
            objRoleMaster = db.RoleMasters.ToList();
            ViewBag.RoleList = objRoleMaster;


            //     List<MenuMaster> objMenuMaster = new List<MenuMaster>();
            //MenuMasterEntities db1 = new MenuMasterEntities();
            //objMenuMaster = db1.MenuMasters.ToList();
            //ViewBag.MenuList = objMenuMaster;



            ProjectMasterEntities db1 = new ProjectMasterEntities();
            var objMenuMaster = db1.MenuMasters.ToList();
            ViewBag.MenuList = objMenuMaster;

            RoleMappMaster objRoleMappMaster = new RoleMappMaster();
            return View(objRoleMappMaster);



        }
            
        }
    
}