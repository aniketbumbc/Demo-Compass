using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Compas_App.Models;
using System.Data;
namespace Demo_Compas_App.Controllers
{
    public class UserMasterController : Controller
    {
        public EntityState EntiyState { get; private set; }
        // GET: UserMaster
        public ActionResult Users()
        {
            using (ProjectMasterEntities dbModel = new ProjectMasterEntities()) 
            {

                return View(dbModel.UserMasters.ToList());
            }

                
        }

        // GET: UserMaster/Details/5
        public ActionResult Details(int id)
        {
            using (ProjectMasterEntities dbModel = new ProjectMasterEntities())
            {
                return View(dbModel.UserMasters.Where(x =>x.UserId==id).FirstOrDefault());

            }
                
        }

        // GET: UserMaster/Create
        public ActionResult Create(int id=0)
        {
            UserMaster usermodel = new UserMaster();
            using (ProjectMasterEntities db = new ProjectMasterEntities())
            {
                usermodel.RoleCollection = db.RoleMasters.ToList<RoleMaster>();
            }
                return View(usermodel);
        }

        // POST: UserMaster/Create
        [HttpPost]
        public ActionResult Create(UserMaster usermaster)
        {
            try
            {
                
                
                    using (ProjectMasterEntities dbModel = new ProjectMasterEntities())
                    {
                        dbModel.UserMasters.Add(usermaster);
                        dbModel.SaveChanges();

                }
                return RedirectToAction("Index");
            }
             
            catch(Exception ex)
            {
                
                return View();
            }
        }

        // GET: UserMaster/Edit/5
        public ActionResult Edit(int id=0)
        {
            //UserMaster usermodel = new UserMaster();
           // using (UserMasterEntities dbModel = new UserMasterEntities())
           //{
               
           //     //usermodel.RoleCollection = dbModel.RoleMasters.ToList<RoleMaster>();
           //     return View(dbModel.UserMasters.Where(x => x.UserId == id).FirstOrDefault());
           // }
            //return View(usermodel);


            UserMaster usermodel = new UserMaster();
            using (ProjectMasterEntities db = new ProjectMasterEntities())
            {
                usermodel = db.UserMasters.Where(x => x.UserId == id).FirstOrDefault();
                usermodel.RoleCollection = db.RoleMasters.ToList<RoleMaster>();
            }
            return View(usermodel);


        }

        // POST: UserMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserMaster usermaster)
        {
            try
            {
                using (ProjectMasterEntities dbModel = new ProjectMasterEntities())
                {
                    dbModel.Entry(usermaster).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserMaster/Delete/5
        public ActionResult Delete(int id)
        {
            using (ProjectMasterEntities dbModel = new ProjectMasterEntities())
            {
                return View(dbModel.UserMasters.Where(x => x.UserId == id).FirstOrDefault());
            }
        }

        // POST: UserMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (ProjectMasterEntities dbModel = new ProjectMasterEntities())
                {
                    UserMaster usermaster = dbModel.UserMasters.Where(x => x.UserId == id).FirstOrDefault();
                    dbModel.UserMasters.Remove(usermaster);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
