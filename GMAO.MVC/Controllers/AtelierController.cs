using GMAO.App.Entities;
using GMAO.App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GMAO.MVC.Controllers
{
    public class AtelierController : Controller
    {
        private readonly IAppAtelierService _AtelierAppService;
        private readonly IAppDepartementService _DepartementAppService;
        private readonly IAppSiteService _SiteAppService;
        public AtelierController(IAppAtelierService AtelierAppService, IAppSiteService SiteAppService, IAppDepartementService DepartementAppService)
        {
            _AtelierAppService = AtelierAppService;
            _DepartementAppService = DepartementAppService;
            _SiteAppService = SiteAppService;

        }
        // GET: Atelier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            return View();

        }


        [HttpGet]
        public JsonResult LoadData(int page, int pageSize = 3)
        {
            var model = _AtelierAppService.GetAll();
            var model1 = _DepartementAppService.GetAll(); //pos
            model1 = model1.OrderBy(x => x.Designation);

            var model2 = _SiteAppService.GetAll();
            model2 = model2.OrderBy(x => x.Name);




            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.code_atelier)
              .Skip((page - 1) * pageSize)
              .Take(pageSize);


            return Json(new
            {
                data = model,
                total = totalRow,
                status = true,
                droplist = model1,
                droplist1 = model2



            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var atelier = _AtelierAppService.GetById(id);
            return Json(new
            {
                data = atelier,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strAtelier)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Atelier_DTO atelier = serializer.Deserialize<Atelier_DTO>(strAtelier);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (atelier.code_atelier == null)
            {
                status = false;
            }

            else
            {


                if (atelier.Id == 0)
                {

                    try
                    {
                        _AtelierAppService.Add(atelier);
                        status = true;
                    }
                    catch (Exception ex)
                    {
                        status = false;
                        message = ex.Message;
                    }
                }
                else
                {
                    //update existing DB
                    //save db

                    var entity = _AtelierAppService.GetById(atelier.Id);
                    entity.code_atelier = atelier.code_atelier;
                    entity.Designation = atelier.Designation;


                    entity.Id = atelier.Id;

                    try
                    {
                        _AtelierAppService.Update(entity);
                        status = true;
                    }
                    catch (Exception ex)
                    {
                        status = false;
                        message = ex.Message;
                    }

                }
            }

            return Json(new
            {
                status = status,
                message = message
            });
        }




        [HttpPost]
        public JsonResult Delete(int id)
        {


            try
            {
                _AtelierAppService.Remove(id);
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex.Message
                });
            }

        }
        public ActionResult Add()
        {
            return View();
        }





        [HttpPost]

        public ActionResult Add(Atelier_DTO obj)
        {
            if (!ModelState.IsValid)
            {

                return Json(false);

            }
            else
            {
                _AtelierAppService.Add(obj);
                return Json(true);

            }
        }
    }
}