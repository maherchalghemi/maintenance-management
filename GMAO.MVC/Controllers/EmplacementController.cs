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
    public class EmplacementController : Controller
    {
        private readonly IAppMagasinService _MagasinAppService;
        private readonly IAppEmplacementService _EmplacementAppService;
        public EmplacementController(IAppMagasinService MagasinAppService, IAppEmplacementService EmplacementAppService)
        {
            _MagasinAppService = MagasinAppService;
            _EmplacementAppService = EmplacementAppService;
        }
        // GET: Magasin
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
            var model = _EmplacementAppService.GetAll();

            var model1 = _MagasinAppService.GetAll();
            model1 = model1.OrderBy(x => x.libelle);


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.Code_Emplacement)
              .Skip((page - 1) * pageSize)
              .Take(pageSize);


            return Json(new
            {
                data = model,
                total = totalRow,
                status = true,
                droplist = model1
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var emplacement = _EmplacementAppService.GetById(id);
            return Json(new
            {
                data = emplacement,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strEmplacement)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Emplacement_DTO emplacement = serializer.Deserialize<Emplacement_DTO>(strEmplacement);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if ((emplacement.Code_Emplacement == null) || (emplacement.Designation == null))
            {
                status = false;
            }

            else
            {


                if (emplacement.Id == 0)
                {

                    try
                    {
                        _EmplacementAppService.Add(emplacement);
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

                    var entity = _EmplacementAppService.GetById(emplacement.Id);
                    entity.Code_Emplacement = emplacement.Code_Emplacement;
                    entity.Designation = emplacement.Designation;
                    entity.magasin = emplacement.magasin;

                    entity.Id = emplacement.Id;

                    try
                    {
                        _EmplacementAppService.Update(entity);
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
                _EmplacementAppService.Remove(id);
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

        public ActionResult Add(Emplacement_DTO obj)
        {
            if ((obj.Code_Emplacement == null) || (obj.Designation == null))
            {

                return Json(false);

            }
            else
            {
                _EmplacementAppService.Add(obj);
                return Json(true);

            }
        }
    }
}