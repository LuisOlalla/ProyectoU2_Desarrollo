using ProyectoU2.Models;
using ProyectoU2.ViewModel;
using System;
using System.IO;
using System.Linq;
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
                                                        Selected = true
                                                    });
            return View(itemViewModel);
        }

        [HttpPost]
        public JsonResult Index(ItemViewModel itemViewModel)
        {
            string NewImage = Guid.NewGuid() + Path.GetExtension(itemViewModel.ImagePath.FileName);
            itemViewModel.ImagePath.SaveAs(Server.MapPath("~/Images/" + NewImage));

            Items objItem = new Items();
            objItem.ImagePath = "~/Images/" + NewImage;
            objItem.CategoryId = itemViewModel.CategoryId;
            objItem.Description = itemViewModel.Description;
            objItem.ItemCode = itemViewModel.ItemCode;
            objItem.ItemId = Guid.NewGuid();
            objItem.ItemName = itemViewModel.ItemName;
            objItem.ItemPrice = itemViewModel.ItemPrice;
            ecartDBEntities.Items.Add(objItem);
            ecartDBEntities.SaveChanges();

            return Json(data: new { Success = true, Message = "Item añadido correctamente." }, JsonRequestBehavior.AllowGet);
        }
    }
}