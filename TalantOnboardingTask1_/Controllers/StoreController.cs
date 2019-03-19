using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalantOnboardingTask1_.Models;
using Newtonsoft.Json;

namespace TalantOnboardingTask1_.Controllers
{
    public class StoreController : Controller
    {
       
    
        public ActionResult Index()
        {
            return View();
        }
        //customerList
        public JsonResult StoreList()
        {
            TalentEntities db = new TalentEntities();
            var StoreList = db.Store_.Select(x => new StoreModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            }).ToList();
            return Json(StoreList, JsonRequestBehavior.AllowGet);
           // return new JsonResult { Data = StoreList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        //Create
        public JsonResult CreateStoreList(Store_ s)
        {

            TalentEntities db = new TalentEntities();
            db.Store_.Add(s);
            db.SaveChanges();

            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //delete
        public JsonResult GetDeleteStoreList(int id)
        {

            TalentEntities db = new TalentEntities();
            var Store = db.Store_.Where(x => x.Id == id).SingleOrDefault();
            string value = JsonConvert.SerializeObject(Store, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return new JsonResult { Data = value, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult DeleteStoreList(int id)
        {
            TalentEntities db = new TalentEntities();
            var Prod = db.Product_.Where(x => x.Id == id).SingleOrDefault();
            if (Prod != null)
            {
                if (Prod.Sales_.Count == 0)
                {
                    db.Product_.Remove(Prod);
                    db.SaveChanges();

                }
                else
                {
                    var sales = db.Sales_.Where(x => x.ProductId == id).ToList();

                    foreach (var sale in sales)
                    {
                        //deleting corresponding sales record
                        db.Sales_.Remove(sale);
                        db.SaveChanges();
                    }
                    db.Product_.Remove(Prod);
                    db.SaveChanges();
                }
            }

            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        public JsonResult GetEdit(int id)
        {

            TalentEntities db = new TalentEntities();
            var Store = db.Store_.Where(x => x.Id == id).SingleOrDefault();
            string value = JsonConvert.SerializeObject(Store, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return new JsonResult { Data = value, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult Edit(Store_ s)
        {

            TalentEntities db = new TalentEntities();
            var Store = db.Store_.Where(x => x.Id == s.Id).SingleOrDefault();
            Store.Name = s.Name;
            Store.Address = s.Address;
            db.SaveChanges();
            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }


    }
}
