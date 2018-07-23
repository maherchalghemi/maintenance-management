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
    public class CategorieEquipementController : Controller
    {
        private readonly IAppCategorieEquipementService _CategorieEquipementAppService;
        public CategorieEquipementController(IAppCategorieEquipementService CategorieEquipementAppService)
        {
            _CategorieEquipementAppService = CategorieEquipementAppService;
        }
        // GET: CategorieEquipement
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
            var model = _CategorieEquipementAppService.GetAll();



            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.code)
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
            var categorieEquipement = _CategorieEquipementAppService.GetById(id);
            return Json(new
            {
                data = categorieEquipement,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strCategorieEquipement)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategorieEquipement_DTO categorieEquipement = serializer.Deserialize<CategorieEquipement_DTO>(strCategorieEquipement);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (categorieEquipement.code == null)
            {
                status = false;
            }

            else
            {


                if (categorieEquipement.Id == 0)
                {

                    try
                    {
                        _CategorieEquipementAppService.Add(categorieEquipement);
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

                    var entity = _CategorieEquipementAppService.GetById(categorieEquipement.Id);
                    entity.code = categorieEquipement.code;
                    entity.Designation = categorieEquipement.Designation;
                    entity.Observation = categorieEquipement.Observation;

                    entity.Id = categorieEquipement.Id;

                    try
                    {
                        _CategorieEquipementAppService.Update(entity);
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
                _CategorieEquipementAppService.Remove(id);
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


    }
}