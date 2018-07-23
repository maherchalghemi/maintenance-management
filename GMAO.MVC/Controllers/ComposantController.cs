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
    public class ComposantController : Controller
    {
        private readonly IAppComposantService _ComposantAppService;
        public ComposantController(IAppComposantService ComposantAppService)
        {
            _ComposantAppService = ComposantAppService;
        }
        // GET: Composant
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
            var model = _ComposantAppService.GetAll();



            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.codeComposant)
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
            var composant = _ComposantAppService.GetById(id);
            return Json(new
            {
                data = composant,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strComposant)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Composant_DTO composant = serializer.Deserialize<Composant_DTO>(strComposant);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (composant.codeComposant == null)
            {
                status = false;
            }

            else
            {


                if (composant.Id == 0)
                {

                    try
                    {
                        _ComposantAppService.Add(composant);
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

                    var entity = _ComposantAppService.GetById(composant.Id);
                    entity.codeComposant = composant.codeComposant;
                    entity.libelle = composant.libelle;
                    entity.NumLot = composant.NumLot;
                    entity.codeBarre = composant.codeBarre;
                    entity.Date_reception = composant.Date_reception;
                    entity.delaiObtention = composant.delaiObtention;
                    entity.NbrExemplaire = composant.NbrExemplaire;
                    entity.Id = composant.Id;

                    try
                    {
                        _ComposantAppService.Update(entity);
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
                _ComposantAppService.Remove(id);
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

        public ActionResult Add(Composant_DTO obj)
        {
            if (!ModelState.IsValid)
            {

                return Json(false);

            }
            else
            {
                _ComposantAppService.Add(obj);
                return Json(true);

            }
        }
    }
}