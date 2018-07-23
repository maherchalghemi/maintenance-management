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
    public class ConsigneMaintenanceController : Controller
    {
        private readonly IAppConsigne_maintenanceService _Consigne_maintenanceAppService;
        private readonly IAppDocumentService _DocumentAppService;
        public ConsigneMaintenanceController(IAppConsigne_maintenanceService Consigne_maintenanceAppService, IAppDocumentService DocumentAppService)
        {
            _Consigne_maintenanceAppService = Consigne_maintenanceAppService;
            _DocumentAppService = DocumentAppService;
        }
        // GET: Consigne_maintenance
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
            var model = _Consigne_maintenanceAppService.GetAll();

            var model1 = _DocumentAppService.GetAll();
            model1 = model1.OrderBy(x => x.libelle);


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.Code_Consigne)
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
            var consigne = _Consigne_maintenanceAppService.GetById(id);
            return Json(new
            {
                data = consigne,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strConsigne)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Consigne_maintenance_DTO consigne = serializer.Deserialize<Consigne_maintenance_DTO>(strConsigne);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if ((consigne.Code_Consigne == null) || (consigne.Designation == null))
            {
                status = false;
            }

            else
            {


                if (consigne.Id == 0)
                {

                    try
                    {
                        _Consigne_maintenanceAppService.Add(consigne);
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

                    var entity = _Consigne_maintenanceAppService.GetById(consigne.Id);
                    entity.Code_Consigne = consigne.Code_Consigne;
                    entity.Designation = consigne.Designation;
                    entity.Description = consigne.Description;
                    entity.Duré_cons_jr = consigne.Duré_cons_jr;
                    entity.Duré_cons_h = consigne.Duré_cons_h;
                    entity.Nb_interv_suggéré = consigne.Nb_interv_suggéré;

                    entity.Id = consigne.Id;

                    try
                    {
                        _Consigne_maintenanceAppService.Update(entity);
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
                _Consigne_maintenanceAppService.Remove(id);
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

        public ActionResult Add(Consigne_maintenance_DTO obj)
        {
            if (!ModelState.IsValid)
            {
               
                return Json(false);

            }
            else
            {
                _Consigne_maintenanceAppService.Add(obj);
                return Json(true);

            }
        }
    }
}