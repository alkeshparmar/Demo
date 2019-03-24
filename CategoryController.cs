using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using TestMVC.DAL;

namespace TestMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDAL cDAl = new CategoryDAL();
        // GET: Category
        public ActionResult Index()
        {
            List<Category> lstCategory = new List<Category>();           
            lstCategory = cDAl.GetAllCategory();
            return View(lstCategory);
        }

        public ActionResult Add()
        {
            Category objCategory = new Category();
            return View(objCategory);
        }

        [HttpPost]

        public ActionResult Add(Category objCategory)
        {
            objCategory.AddedBy = "Admin";
            objCategory.AddedOn = DateTime.Now;
            int i = cDAl.AddCategory(objCategory);
            if (i == 0)
            {
                ViewBag.Message = "Data Added Successfully";
            }
            return View(objCategory);
        }

        public ActionResult Edit(string id)
        {
            Category objCategory = new Category();
            objCategory = cDAl.GetCategoryBYID(Convert.ToInt32(id));
            return View(objCategory);
        }

        [HttpPost]
        public ActionResult Edit(Category objCategory)
        {
            objCategory.UpdateBy = "Admin";
            objCategory.UpdateOn = DateTime.Now;
            int i = cDAl.UpdateCategory(objCategory);
            if(i==0)
            {
                ViewBag.Message = "Data Added Successfully";
            }
            return View(objCategory);
        }
        
        public ActionResult Delete(string id)
        {            
            cDAl.DeleteCategory(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }
    }
}