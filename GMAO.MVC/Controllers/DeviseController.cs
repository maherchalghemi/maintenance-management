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
    public class DeviseController : Controller
    {
        private readonly IAppDeviseService _DeviseAppService;
        public DeviseController(IAppDeviseService DeviseAppService)
        {
            _DeviseAppService = DeviseAppService;
        }
        // GET: Devise
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
            var model = _DeviseAppService.GetAll();



            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.codeDevise)
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
            var devise = _DeviseAppService.GetById(id);
            return Json(new
            {
                data = devise,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strDevise)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Devise_DTO devise = serializer.Deserialize<Devise_DTO>(strDevise);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (devise.codeDevise == null)
            {
                status = false;
            }

            else
            {


                if (devise.Id == 0)
                {

                    try
                    {
                        _DeviseAppService.Add(devise);
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

                    var entity = _DeviseAppService.GetById(devise.Id);
                    entity.codeDevise = devise.codeDevise;
                    entity.Designation = devise.Designation;
                    entity.nb = devise.nb;
                    entity.decimale = devise.decimale;

                    entity.Id = devise.Id;

                    try
                    {
                        _DeviseAppService.Update(entity);
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
                _DeviseAppService.Remove(id);
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

        public ActionResult Add(Devise_DTO obj)
        {
            if (!ModelState.IsValid)
            {

                return Json(false);

            }
            else
            {
                _DeviseAppService.Add(obj);
                return Json(true);

            }
        }
    }
}