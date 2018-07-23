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
    public class CompteurController : Controller
    {
        private readonly IAppCompteurService _CompteurAppService;
        public CompteurController(IAppCompteurService CompteurAppService)
        {
            _CompteurAppService = CompteurAppService;
        }
        // GET: Compteur
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
            var model = _CompteurAppService.GetAll();



            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.codeCompt)
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
            var compteur = _CompteurAppService.GetById(id);
            return Json(new
            {
                data = compteur,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strCompteur)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Compteur_DTO compteur = serializer.Deserialize<Compteur_DTO>(strCompteur);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (compteur.codeCompt == null)
            {
                status = false;
            }

            else
            {


                if (compteur.Id == 0)
                {

                    try
                    {
                        _CompteurAppService.Add(compteur);
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

                    var entity = _CompteurAppService.GetById(compteur.Id);
                    entity.codeCompt = compteur.codeCompt;
                    entity.unite = compteur.unite;
                    entity.valeur_compteur_max = compteur.valeur_compteur_max;

                    entity.Id = compteur.Id;

                    try
                    {
                        _CompteurAppService.Update(entity);
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
                _CompteurAppService.Remove(id);
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

        public ActionResult Add(Compteur_DTO obj)
        {
            if (!ModelState.IsValid)
            {

                return Json(false);

            }
            else
            {
                _CompteurAppService.Add(obj);
                return Json(true);

            }
        }
    }
}