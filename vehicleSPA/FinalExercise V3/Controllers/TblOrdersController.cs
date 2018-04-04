using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalExercise_V3.Models;
using FinalExercise_V3.Interface;
using FinalExercise_V3.Repositories;

namespace FinalExercise_V3.Controllers
{
    public class TblOrdersController : Controller
    {
        static readonly IShoppingCartRepository repository = new ShoppingCartRepository();

        public ActionResult Orders()
        {
            return View();
        }

        public JsonResult GetAllOrders()
        {
            return Json(repository.GetAll(), JsonRequestBehavior.AllowGet);
        }
        
        // This code works but only can send one cartline to the database
        public JsonResult AddOrder(TblOrder item)
        {           
            item = repository.Add(item);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        

         /*
        //This code was to try to send multiple cartlines to database; it did not work.
        public JsonResult AddOrder(List<TblOrder> items)
        {
            foreach (var item in items)
            {
                repository.Add(item);             
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        */
        public JsonResult EditOrder(int id, TblOrder product)
        {
            product.Id = id;
            if (repository.Update(product))
            {
                return Json(repository.GetAll(), JsonRequestBehavior.AllowGet);
            }

            return Json(null);
        }

        public JsonResult DeleteOrder(int id)
        {

            if (repository.Delete(id))
            {
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Status = false }, JsonRequestBehavior.AllowGet);

        }
    }
}
