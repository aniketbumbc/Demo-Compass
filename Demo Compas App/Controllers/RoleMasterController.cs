using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Compas_App.Models;
using System.Web.Routing;
using System.Data;

namespace Demo_Compas_App.Controllers
{
    public class RoleMasterController : Controller
    {
        public EntityState EntiyState { get; private set; }

        // GET: RoleMaster
        public ActionResult Index()
        {
            using (RoleMasterEntities dbModel = new RoleMasterEntities())
            {
                return View(dbModel.RoleMasters.ToList()); // Get All Role Master Name into view 
            }
        }

        // GET: RoleMaster/Details/5
        public ActionResult Details(int id)
        {
            using (RoleMasterEntities dbModel = new RoleMasterEntities())
            {
                return View(dbModel.RoleMasters.Where(x =>x.RoleId==id).FirstOrDefault());
            }

            
        }

        // GET: RoleMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleMaster/Create

        [HttpPost]
        public ActionResult Create(RoleMaster rolemaster)
        {
            try
            {
                using (RoleMasterEntities dbModel = new RoleMasterEntities())
                {
                    dbModel.RoleMasters.Add(rolemaster); // Add to Database
                    dbModel.SaveChanges();// Add or Save to Database
                }

                    return RedirectToAction("Index"); // redirect to index action 
            }
            catch
            {
                return View();
            }
        }
       
        public ActionResult Edit(int id)
        {
            using (RoleMasterEntities dbModel = new RoleMasterEntities())
            {
                return View(dbModel.RoleMasters.Where(x => x.RoleId == id).FirstOrDefault());
            }
        }       
        [HttpPost]
        public ActionResult Edit(int id, RoleMaster rolemaster)
        {
            try
            {
                using (RoleMasterEntities dbModel = new RoleMasterEntities())
                {
                    dbModel.Entry(rolemaster).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }      
        public ActionResult Delete(int id)
        {
            using (RoleMasterEntities dbModel = new RoleMasterEntities())
            {
                return View(dbModel.RoleMasters.Where(x => x.RoleId == id).FirstOrDefault());
            }
        }
      
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (RoleMasterEntities dbModel = new RoleMasterEntities())
                {
                    RoleMaster rolemaster =dbModel.RoleMasters.Where(x => x.RoleId == id).FirstOrDefault();
                    dbModel.RoleMasters.Remove(rolemaster);
                    dbModel.SaveChanges();
                }
                TempData["AlertMessage"] = "Role Delete Sucessfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
