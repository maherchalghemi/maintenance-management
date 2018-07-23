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
    public class MagasinController : Controller
    {
        private readonly IAppMagasinService _MagasinAppService;
        private readonly IAppEmplacementService _EmplacementAppService;
        public MagasinController(IAppMagasinService MagasinAppService , IAppEmplacementService EmplacementAppService)
        {
            _MagasinAppService = MagasinAppService;
            _EmplacementAppService = EmplacementAppService;
        }
        // GET: Magasin
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
            var model = _MagasinAppService.GetAll();

            var model1 = _EmplacementAppService.GetAll(); // i want display 
           // model1 = model1.OrderByDescending(x => x.Designation); in drowpdown !! you undersand me??yes
           

            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.Code_magasin)
              .Skip((page - 1) * pageSize)
              .Take(pageSize);


            return Json(new
            {
                data = model,
                total = totalRow,
                status = true,
                droplist=model1
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var magasin = _MagasinAppService.GetById(id);
            return Json(new
            {
                data = magasin,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strMagasin)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Magasin_DTO magasin = serializer.Deserialize<Magasin_DTO>(strMagasin);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if ((magasin.Code_magasin == null) || (magasin.libelle == null))
            {
                status = false;
            }

            else { 


            if (magasin.Id == 0)
            {

                try
                {
                    _MagasinAppService.Add(magasin);
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

                var entity = _MagasinAppService.GetById(magasin.Id);
                entity.Code_magasin = magasin.Code_magasin;
                entity.libelle = magasin.libelle;
                entity.tel = magasin.tel;
                entity.Adresse = magasin.Adresse;
                entity.obsrvation = magasin.obsrvation;
                entity.Id = magasin.Id;

                try
                {
                    _MagasinAppService.Update(entity);
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
                _MagasinAppService.Remove(id);
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

        public ActionResult Add(Magasin_DTO obj)
        {
            if ((obj.Code_magasin == null) || (obj.libelle == null))
            {

                return Json(false);

            }
            else
            {
                _MagasinAppService.Add(obj);
                return Json(true);

            }
        }
    }
}