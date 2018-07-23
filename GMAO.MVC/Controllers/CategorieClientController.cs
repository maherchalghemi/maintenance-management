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
    public class CategorieClientController : Controller
    {
        private readonly IAppCategorieClientService _CategorieClientAppService;
        public CategorieClientController(IAppCategorieClientService CategorieClientAppService)
        {
            _CategorieClientAppService = CategorieClientAppService;
        }
        // GET: CategorieClient
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
            var model = _CategorieClientAppService.GetAll();



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
            var categorieClient = _CategorieClientAppService.GetById(id);
            return Json(new
            {
                data = categorieClient,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strCategorieClient)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategorieClient_DTO categorieClient = serializer.Deserialize<CategorieClient_DTO>(strCategorieClient);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (categorieClient.code == null)
            {
                status = false;
            }

            else
            {


                if (categorieClient.Id == 0)
                {

                    try
                    {
                        _CategorieClientAppService.Add(categorieClient);
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

                    var entity = _CategorieClientAppService.GetById(categorieClient.Id);
                    entity.code = categorieClient.code;
                    entity.Designation = categorieClient.Designation;


                    entity.Id = categorieClient.Id;

                    try
                    {
                        _CategorieClientAppService.Update(entity);
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
                _CategorieClientAppService.Remove(id);
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