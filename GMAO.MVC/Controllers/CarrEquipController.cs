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
    public class CarrEquipController : Controller
    {
        private readonly IAppCarr_EquipService _Carr_EquipAppService;
        public CarrEquipController(IAppCarr_EquipService Carr_EquipAppService)
        {
            _Carr_EquipAppService = Carr_EquipAppService;
        }
        // GET: Carr_Equip
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            return View(); ;

        }



        [HttpGet]
        public JsonResult LoadData(int page, int pageSize = 3)
        {
            var model = _Carr_EquipAppService.GetAll();



            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.Code_cause)
              .Skip((page - 1) * pageSize)
              .Take(pageSize);


            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var carrEquip = _Carr_EquipAppService.GetById(id);
            return Json(new
            {
                data = carrEquip,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strCarrEquip)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Carr_Equip_DTO carrEquip = serializer.Deserialize<Carr_Equip_DTO>(strCarrEquip);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if ((carrEquip.Code_cause == null) || (carrEquip.libelle == null))
            {
                status = false;
            }

            else
            {


                if (carrEquip.Id == 0)
                {

                    try
                    {
                        _Carr_EquipAppService.Add(carrEquip);
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

                    var entity = _Carr_EquipAppService.GetById(carrEquip.Id);
                    entity.Code_cause = carrEquip.Code_cause;
                    entity.libelle = carrEquip.libelle;
                    entity.taux_horaire = carrEquip.taux_horaire;
                    entity.panne = carrEquip.panne;

                    entity.Id = carrEquip.Id;

                    try
                    {
                        _Carr_EquipAppService.Update(entity);
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
                _Carr_EquipAppService.Remove(id);
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

        public ActionResult Add(Carr_Equip_DTO obj)
        {
            if ((obj.Code_cause == null) || (obj.libelle == null))
            {
               
                return Json(false);

            }
            else
            {
                _Carr_EquipAppService.Add(obj);
                return Json(true);

            }
        }
    }
}