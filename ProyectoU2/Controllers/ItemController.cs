using ProyectoU2.Models;
using ProyectoU2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ProyectoU2.Controllers
{
    public class ItemController : Controller
    {
        private EcartDBEntities ecartDBEntities;
        public ItemController()
        {
            ecartDBEntities = new EcartDBEntities();
        }
        // GET: Item
        public ActionResult Index()
        {
            ItemViewModel itemViewModel = new ItemViewModel();
            itemViewModel.CategorySelectListItem = (from objCat in ecartDBEntities.Categories
                                                    select new SelectListItem()
                                                    {
                                                        Text = objCat.CategoryName,
                                                        Value = objCat.CategoryId.ToString(),
                                                        Selected= true
                                                    });
            return View(itemViewModel);
        }
        public JsonResult Index(ItemViewModel itemViewModel)
        {
            return Json("HHH", JsonRequestBehavior.AllowGet);
        }
    }
}