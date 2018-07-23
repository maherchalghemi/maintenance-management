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
    public class CategorieOutillageController : Controller
    {

        private readonly IAppCategorieOutillageService _CategorieOutillageAppService;
        public CategorieOutillageController(IAppCategorieOutillageService CategorieOutillageAppService)
        {
            _CategorieOutillageAppService = CategorieOutillageAppService;
        }

        // GET: CategorieOutillage
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
            var model = _CategorieOutillageAppService.GetAll();



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
            var categorieOutillage = _CategorieOutillageAppService.GetById(id);
            return Json(new
            {
                data = categorieOutillage,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strCategorieOutillage)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategorieOutillage_DTO categorieOutillage = serializer.Deserialize<CategorieOutillage_DTO>(strCategorieOutillage);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (categorieOutillage.code == null)
            {
                status = false;
            }

            else
            {


                if (categorieOutillage.Id == 0)
                {

                    try
                    {
                        _CategorieOutillageAppService.Add(categorieOutillage);
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

                    var entity = _CategorieOutillageAppService.GetById(categorieOutillage.Id);
                    entity.code = categorieOutillage.code;
                    entity.Designation = categorieOutillage.Designation;
                    entity.Observation = categorieOutillage.Observation;

                    entity.Id = categorieOutillage.Id;

                    try
                    {
                        _CategorieOutillageAppService.Update(entity);
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
                _CategorieOutillageAppService.Remove(id);
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