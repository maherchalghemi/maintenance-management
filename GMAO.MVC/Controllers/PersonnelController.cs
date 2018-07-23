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
    
    public class PersonnelController : Controller
    {
        private readonly IAppPersonnelService _PersonnelAppService;
        private readonly IAppDepartementService _DepartementAppService;
        public PersonnelController(IAppPersonnelService PersonnelAppService ,IAppDepartementService DepartementAppService)
        {
            _PersonnelAppService = PersonnelAppService;
            _DepartementAppService = DepartementAppService;
        }
        // GET: Personnel
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
            var model = _PersonnelAppService.GetAll();
            var model1 = _DepartementAppService.GetAll();
            model1 = model1.OrderBy(x => x.Designation);


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.Matricule)
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
            var personnel = _PersonnelAppService.GetById(id);
            return Json(new
            {
                data = personnel,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strPersonnel)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Personnel_DTO personnel = serializer.Deserialize<Personnel_DTO>(strPersonnel);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (personnel.Matricule == null)
            {
                status = false;
            }

            else
            {


                if (personnel.Id == 0)
                {
                    personnel.NomPrenom = personnel.Nom + " " + personnel.Prenom ;
                    


                    try
                    {
                        _PersonnelAppService.Add(personnel);
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

                    var entity = _PersonnelAppService.GetById(personnel.Id);
                    entity.Matricule = personnel.Matricule;
                    entity.Nom = personnel.Nom;
                    entity.NomPrenom = personnel.NomPrenom;
                    entity.DateNaissance = personnel.DateNaissance;
                    entity.CIN = personnel.CIN;
                    entity.DateAjout = personnel.DateAjout;
                    entity.Adresse = personnel.Adresse;
                    entity.Tel = personnel.Tel;
                    entity.GSM = personnel.GSM;
                    entity.Grade = personnel.Grade;
                    entity.Prenom = personnel.Prenom;



                    entity.Id = personnel.Id;

                    try
                    {
                        _PersonnelAppService.Update(entity);
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
                _PersonnelAppService.Remove(id);
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
            var model = new Personnel_DTO()
            {
                dep = _DepartementAppService.GetAll().ToList()
            };
            
            return View(model);
        }



        

        [HttpPost]

        public ActionResult Add(Personnel_DTO obj)
        {
            if (!ModelState.IsValid)
            {
               
                return Json(false);

            }
            else
            {
                _PersonnelAppService.Add(obj);
                return Json(true);

            }
        }
    }
}