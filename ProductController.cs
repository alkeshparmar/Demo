using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.DAL;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class ProductController : Controller
    {
        CategoryDAL cDAl = new CategoryDAL();
        ProductDAL pDAL = new ProductDAL();
        // GET: Product
        public ActionResult Index()
        {
            List<Category> lstCategory = cDAl.GetAllCategory();
            List<Product> lstProduct = pDAL.GetAllProduct();
            var studentViewModel = from c in lstCategory
                                   join p in lstProduct on c.cid equals p.cid into temp
                                   from p in temp.DefaultIfEmpty()
                                   select new ViewProduct { CategoryVM = c, ProductVM = p };
            return View(studentViewModel);
        }

        public ActionResult Add()
        {
            List<Category> lstCategory = cDAl.GetAllCategory();
            ViewBag.cname = new SelectList(lstCategory, "cid", "cname");
            Product objProduct = new Product();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Add(Product objProduct, HttpPostedFileBase images)
        {
            if (images != null)
            {
                string path = Path.Combine(Server.MapPath("~/UploadedFiles/"), Path.GetFileName(images.FileName));
                images.SaveAs(path);
                ViewBag.path = "~/UploadedFiles/" + Path.GetFileName(images.FileName);
            }
            objProduct.AddedBy = "Admin";
            objProduct.AddedOn = DateTime.Now;

            objProduct.images = Path.GetFileName(images.FileName);
            objProduct.ImageURL = ViewBag.path;
            int i = pDAL.AddProduct(objProduct);
            if (i == 0)
            {
                ViewBag.Message = "Data Added Sucessfully";
            }
            //return View(objProduct);
            return RedirectToAction("Add");
        }

        public ActionResult Edit(string id)
        {
            List<Category> lstCategory = cDAl.GetAllCategory();
            ViewBag.cname = new SelectList(lstCategory, "cid", "cname");
            Product objProduct = pDAL.GetProductBYID(Convert.ToInt32(id));
            Session["Image"] = objProduct.images;
            Session["ImagePath"] = objProduct.ImageURL;
            return View(objProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product objProduct, HttpPostedFileBase images)
        {
            if (images != null)
            {
                string path = Path.Combine(Server.MapPath("~/UploadedFiles/"), Path.GetFileName(images.FileName));
                images.SaveAs(path);
                ViewBag.path = "~/UploadedFiles/" + Path.GetFileName(images.FileName);
                objProduct.images = Path.GetFileName(images.FileName);
                objProduct.ImageURL = ViewBag.path;
            }
            else
            {
                objProduct.images = Convert.ToString(Session["Image"]);
                objProduct.ImageURL = Convert.ToString(Session["ImagePath"]);
            }
            objProduct.UpdateBy = "Admin";
            objProduct.UpdateOn = DateTime.Now;

            int i = pDAL.UpdateProduct(objProduct);
            List<Category> lstCategory = cDAl.GetAllCategory();
            ViewBag.cname = new SelectList(lstCategory, "cid", "cname");
            if (i == 0)
            {
                ViewBag.Message = "Data Added Sucessfully";
            }

            return View(objProduct);
        }

        public ActionResult Delete(string id)
        {
            pDAL.DeleteProduct(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }
    }
}