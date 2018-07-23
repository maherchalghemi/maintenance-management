using GMAO.App.Entities;
using GMAO.App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMAO.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IAppCategoryService _AppCategoryService;

        public CategoryController(IAppCategoryService AppCategoryService)
        {
            _AppCategoryService = AppCategoryService;


        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return PartialView("_AddCategory");
        }

        [HttpPost]
        public ActionResult Add(Category_DTO obj)
        {
            
                _AppCategoryService.Add(obj);



                return RedirectToAction("Client/Add"); 
        }
    }
}