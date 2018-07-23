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
    public class CategoriePieceRechangeController : Controller
    {
        private readonly IAppCategoriePieceRechangeService _CategoriePieceRechangeAppService;
        public CategoriePieceRechangeController(IAppCategoriePieceRechangeService CategoriePieceRechangeAppService)
        {
            _CategoriePieceRechangeAppService = CategoriePieceRechangeAppService;
        }
        // GET: CategoriePieceRechange
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
            var model = _CategoriePieceRechangeAppService.GetAll();



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
            var categoriePieceRechange = _CategoriePieceRechangeAppService.GetById(id);
            return Json(new
            {
                data = categoriePieceRechange,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strCategoriePieceRechange)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategoriePieceRechange_DTO categoriePieceRechange = serializer.Deserialize<CategoriePieceRechange_DTO>(strCategoriePieceRechange);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (categoriePieceRechange.code == null)
            {
                status = false;
            }

            else
            {


                if (categoriePieceRechange.Id == 0)
                {

                    try
                    {
                        _CategoriePieceRechangeAppService.Add(categoriePieceRechange);
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

                    var entity = _CategoriePieceRechangeAppService.GetById(categoriePieceRechange.Id);
                    entity.code = categoriePieceRechange.code;
                    entity.Designation = categoriePieceRechange.Designation;
                    entity.Observation = categoriePieceRechange.Observation;

                    entity.Id = categoriePieceRechange.Id;

                    try
                    {
                        _CategoriePieceRechangeAppService.Update(entity);
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
                _CategoriePieceRechangeAppService.Remove(id);
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