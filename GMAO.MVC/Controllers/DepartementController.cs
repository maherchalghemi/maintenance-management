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
    public class DepartementController : Controller
    {
        private readonly IAppDepartementService _DepartementAppService;
        private readonly IAppSiteService _SiteAppService;
        public DepartementController(IAppDepartementService DepartementAppService , IAppSiteService SiteAppService)
        {
            _DepartementAppService = DepartementAppService;
            _SiteAppService = SiteAppService;
        }
        // GET: Departement
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
            var model = _DepartementAppService.GetAll();
            var model1 = _SiteAppService.GetAll();
            model1 = model1.OrderBy(x => x.Name);


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.NumDepartement)
              .Skip((page - 1) * pageSize)
              .Take(pageSize);


            return Json(new
            {
                data = model,
                total = totalRow,
                status = true,
                droplist = model1
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var departement = _DepartementAppService.GetById(id);
            return Json(new
            {
                data = departement,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strDepartement)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Departement_DTO departement = serializer.Deserialize<Departement_DTO>(strDepartement);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (departement.NumDepartement == null)
            {
                status = false;
            }

            else
            {


                if (departement.Id == 0)
                {

                    try
                    {
                        _DepartementAppService.Add(departement);
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

                    var entity = _DepartementAppService.GetById(departement.Id);
                    entity.NumDepartement = departement.NumDepartement;
                    entity.Designation = departement.Designation;
                    entity.Description = departement.Description;


                    entity.Id = departement.Id;

                    try
                    {
                        _DepartementAppService.Update(entity);
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
                _DepartementAppService.Remove(id);
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

        public ActionResult Add(Departement_DTO obj)
        {
            if (!ModelState.IsValid)
            {

                return Json(false);

            }
            else
            {
                _DepartementAppService.Add(obj);
                return Json(true);

            }
        }
    }
}