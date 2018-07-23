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
    public class RangementController : Controller
    {

        private readonly IAppRangementService _RangementAppService;
        public RangementController(IAppRangementService RangementAppService)
        {
            _RangementAppService = RangementAppService;
        }
        // GET: Rangement
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
            var model = _RangementAppService.GetAll();



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
            var rangement = _RangementAppService.GetById(id);
            return Json(new
            {
                data = rangement,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strRangement)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Rangement_DTO rangement = serializer.Deserialize<Rangement_DTO>(strRangement);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (rangement.code == null)
            {
                status = false;
            }

            else
            {


                if (rangement.Id == 0)
                {

                    try
                    {
                        _RangementAppService.Add(rangement);
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

                    var entity = _RangementAppService.GetById(rangement.Id);
                    entity.code = rangement.code;
                    entity.Designation = rangement.Designation;


                    entity.Id = rangement.Id;

                    try
                    {
                        _RangementAppService.Update(entity);
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
                _RangementAppService.Remove(id);
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