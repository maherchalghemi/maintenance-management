using GMAO.App.Entities;
using GMAO.App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMAO.MVC.Controllers
{
    public class OutillageController : Controller
    {
        private readonly IAppOutillageService _OutillageAppService;
        public OutillageController(IAppOutillageService OutillageAppService)
        {
            _OutillageAppService = OutillageAppService;
        }
        // GET: Outillage
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetAll()
        {
            var model = _OutillageAppService.GetAll();
            return PartialView("GetAll", model);

        }
        public ActionResult Add()
        {
            return View();
        }





        [HttpPost]

        public ActionResult Add(Outillage_DTO obj)
        {
           if (obj.codeoutil!=null && obj.designation!=null)
            {
                _OutillageAppService.Add(obj);
                return Json(true);
                

            }

           else
           {
               return Json(false);
           }
           
        }
    }
}