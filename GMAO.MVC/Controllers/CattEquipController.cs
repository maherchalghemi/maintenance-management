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
    public class CattEquipController : Controller
    {
        private readonly IAppCatt_EquipService _Catt_EquipAppService;
        public CattEquipController(IAppCatt_EquipService Catt_EquipAppService)
        {
            _Catt_EquipAppService = Catt_EquipAppService;
        }
        // GET: Catt_Equip
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
            var model = _Catt_EquipAppService.GetAll();



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
            var cattEquip = _Catt_EquipAppService.GetById(id);
            return Json(new
            {
                data = cattEquip,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strCattEquip)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Catt_Equip_DTO cattEquip = serializer.Deserialize<Catt_Equip_DTO>(strCattEquip);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if ((cattEquip.Code_cause == null) || (cattEquip.libelle == null))
            {
                status = false;
            }

            else
            {


                if (cattEquip.Id == 0)
                {

                    try
                    {
                        _Catt_EquipAppService.Add(cattEquip);
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

                    var entity = _Catt_EquipAppService.GetById(cattEquip.Id);
                    entity.Code_cause = cattEquip.Code_cause;
                    entity.libelle = cattEquip.libelle;
                    entity.taux_horaire = cattEquip.taux_horaire;
                    entity.panne = cattEquip.panne;

                    entity.Id = cattEquip.Id;

                    try
                    {
                        _Catt_EquipAppService.Update(entity);
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
                _Catt_EquipAppService.Remove(id);
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

        public ActionResult Add(Catt_Equip_DTO obj)
        {
            if ((obj.Code_cause == null) || (obj.libelle == null))
            {
               
                return Json(false);

            }
            else
            {
                _Catt_EquipAppService.Add(obj);
                return Json(true);

            }
        }
    }
}