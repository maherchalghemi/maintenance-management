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
    public class SiteController : Controller
    {
        private readonly IAppSiteService _SiteAppService;
        public SiteController(IAppSiteService SiteAppService)
        {
            _SiteAppService = SiteAppService;
        }
        // GET: Site
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
            var model = _SiteAppService.GetAll();



            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.code_site)
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
            var site = _SiteAppService.GetById(id);
            return Json(new
            {
                data = site,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strSite)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Site_DTO site = serializer.Deserialize<Site_DTO>(strSite);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (site.code_site == null)
            {
                status = false;
            }

            else
            {


                if (site.Id == 0)
                {

                    try
                    {
                        _SiteAppService.Add(site);
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

                    var entity = _SiteAppService.GetById(site.Id);
                    entity.code_site = site.code_site;
                    entity.Name = site.Name;
                    entity.adresse_site = site.adresse_site;
                    entity.Code_postale = site.Code_postale;
                    entity.Ville = site.Ville;
                    entity.pays = site.pays;
                    entity.no_tel = site.no_tel;
                    entity.no_fax = site.no_fax;
                    entity.email = site.email;
                    entity.Id = site.Id;

                    try
                    {
                        _SiteAppService.Update(entity);
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
                _SiteAppService.Remove(id);
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

        public ActionResult Add(Site_DTO obj)
        {
            if (!ModelState.IsValid)
            {

                return Json(false);

            }
            else
            {
                _SiteAppService.Add(obj);
                return Json(true);

            }
        }
    }
}