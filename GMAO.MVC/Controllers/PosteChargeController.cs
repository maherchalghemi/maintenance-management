using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMAO.App.Entities;
using GMAO.App.Interface;
using System.Web.Script.Serialization;

namespace GMAO.MVC.Controllers
{
   public class PosteChargeController : Controller
    {
        private readonly IAppPoste_de_chargeService _Poste_de_chargeAppService;
        private readonly IAppAtelierService _AtelierAppService;
        public PosteChargeController(IAppPoste_de_chargeService Poste_de_chargeAppService, IAppAtelierService AtelierAppService)
        {
            _Poste_de_chargeAppService = Poste_de_chargeAppService;
            _AtelierAppService = AtelierAppService;
        }
        // GET: Poste_de_charge
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
            var model = _Poste_de_chargeAppService.GetAll();

            var model1 = _AtelierAppService.GetAll();
            model1 = model1 = model1.OrderBy(x => x.Designation);


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.code_poste)
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
            var Poste_de_charge = _Poste_de_chargeAppService.GetById(id);
            return Json(new
            {
                data = Poste_de_charge,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strPoste)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Poste_de_charge_DTO poste = serializer.Deserialize<Poste_de_charge_DTO>(strPoste);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if ((poste.code_poste == null) || (poste.Designation == null))
            {
                status = false;
            }

            else
            {


                if (poste.Id == 0)
                {

                    try
                    {
                        _Poste_de_chargeAppService.Add(poste);
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

                    var entity = _Poste_de_chargeAppService.GetById(poste.Id);
                    entity.code_poste = poste.code_poste;
                    entity.Designation = poste.Designation;
                    

                    entity.Id = poste.Id;

                    try
                    {
                        _Poste_de_chargeAppService.Update(entity);
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
                _Poste_de_chargeAppService.Remove(id);
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

        public ActionResult Add(Poste_de_charge_DTO obj)
        {
            if (!ModelState.IsValid)
            {
               
                return Json(false);

            }
            else
            {
                _Poste_de_chargeAppService.Add(obj);
                return Json(true);

            }
        }
    }
}