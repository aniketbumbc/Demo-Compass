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
        public ActionResult Index()
        {
            using (UserMasterEntities dbModel = new UserMasterEntities()) 
            {

                return View(dbModel.UserMasters.ToList());
            }

                
        }

        // GET: UserMaster/Details/5
        public ActionResult Details(int id)
        {
            using (UserMasterEntities dbModel = new UserMasterEntities())
            {
                return View(dbModel.UserMasters.Where(x =>x.UserId==id).FirstOrDefault());

            }
                
        }

        // GET: UserMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserMaster/Create
        [HttpPost]
        public ActionResult Create(UserMaster usermaster)
        {
            try
            {
                
                
                    using (UserMasterEntities dbModel = new UserMasterEntities())
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
        public ActionResult Edit(int id)
        {
            using (UserMasterEntities dbModel = new UserMasterEntities())
            {
                return View(dbModel.UserMasters.Where(x => x.UserId==id).FirstOrDefault());
            }
                
        }

        // POST: UserMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserMaster usermaster)
        {
            try
            {
                using (UserMasterEntities dbModel = new UserMasterEntities())
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
            using (UserMasterEntities dbModel = new UserMasterEntities())
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
                using (UserMasterEntities dbModel = new UserMasterEntities())
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
