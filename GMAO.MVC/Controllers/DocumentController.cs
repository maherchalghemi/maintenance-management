using GMAO.App.Entities;
using GMAO.App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMAO.MVC.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IAppDocumentService _DocumentAppService;
        public DocumentController(IAppDocumentService DocumentAppService)
        {
            _DocumentAppService = DocumentAppService;
        }
        // GET: Document
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetAll()
        {
            var model = _DocumentAppService.GetAll();
            return PartialView("GetAll", model);

        }

        public ActionResult Add()
        {
            return View();
        }





        [HttpPost]

        public ActionResult Add(Document_DTO obj)
        {
            if (!ModelState.IsValid)
            {

                return Json(false);

            }
            else
            {
                _DocumentAppService.Add(obj);
                return Json(true);

            }
        }
    }
}