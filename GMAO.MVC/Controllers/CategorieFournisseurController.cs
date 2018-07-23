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
    public class CategorieFournisseurController : Controller
    {
        private readonly IAppCategorieFournisseurService _CategorieFournisseurAppService;
        public CategorieFournisseurController(IAppCategorieFournisseurService CategorieFournisseurAppService)
        {
            _CategorieFournisseurAppService = CategorieFournisseurAppService;
        }
        // GET: CategorieFournisseur
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
            var model = _CategorieFournisseurAppService.GetAll();



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
            var categorieFournisseur = _CategorieFournisseurAppService.GetById(id);
            return Json(new
            {
                data = categorieFournisseur,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strCategorieFournisseur)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CategorieFournisseur_DTO categorieFournisseur = serializer.Deserialize<CategorieFournisseur_DTO>(strCategorieFournisseur);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (categorieFournisseur.code == null)
            {
                status = false;
            }

            else
            {


                if (categorieFournisseur.Id == 0)
                {

                    try
                    {
                        _CategorieFournisseurAppService.Add(categorieFournisseur);
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

                    var entity = _CategorieFournisseurAppService.GetById(categorieFournisseur.Id);
                    entity.code = categorieFournisseur.code;
                    entity.Designation = categorieFournisseur.Designation;


                    entity.Id = categorieFournisseur.Id;

                    try
                    {
                        _CategorieFournisseurAppService.Update(entity);
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
                _CategorieFournisseurAppService.Remove(id);
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