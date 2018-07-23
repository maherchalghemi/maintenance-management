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
    public class EquipementController : Controller
    {
        private readonly IAppEquipementService _EquipementAppService;
        private readonly IAppPoste_de_chargeService _Poste_de_chargeAppService;
        private readonly IAppCategorieEquipementService _CategorieEquipementAppService;
        private readonly IAppFournisseurService _FournisseurAppService;
        private readonly IAppClientService _ClientAppService;
        public EquipementController(IAppEquipementService EquipementAppService, IAppPoste_de_chargeService Poste_de_chargeAppService, IAppCategorieEquipementService CategorieEquipementAppService, IAppFournisseurService FournisseurAppService, IAppClientService ClientAppService)
        {
            _EquipementAppService = EquipementAppService;
            _Poste_de_chargeAppService = Poste_de_chargeAppService;
            _CategorieEquipementAppService = CategorieEquipementAppService;
            _FournisseurAppService = FournisseurAppService;
            _ClientAppService = ClientAppService;
        }
        // GET: Equipement
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
            var model = _EquipementAppService.GetAll();
            var model1 = _Poste_de_chargeAppService.GetAll(); //pos
            model1 = model1.OrderBy(x => x.Designation);

            var model2 = _CategorieEquipementAppService.GetAll();
            model2 = model2.OrderBy(x => x.Designation);

            var model3 = _FournisseurAppService.GetAll();
            model3 = model3.OrderBy(x => x.Nom); //Fourni

            var model4 = _ClientAppService.GetAll();
            model4 = model4.OrderBy(x => x.NomContact); //client


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.CodeEquipement)
              .Skip((page - 1) * pageSize)
              .Take(pageSize);


            return Json(new
            {
                data = model,
                total = totalRow,
                status = true,
                droplist = model1, // pos
                droplist1 = model2, // cat
                droplist2 = model3, //Fourni
                droplist3 = model4 //client


            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var equipement = _EquipementAppService.GetById(id);
            return Json(new
            {
                data = equipement,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strEquipement)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Equipement_DTO equipement = serializer.Deserialize<Equipement_DTO>(strEquipement);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (equipement.CodeEquipement == null)
            {
                status = false;
            }

            else
            {


                if (equipement.Id == 0)
                {

                    try
                    {
                        _EquipementAppService.Add(equipement);
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

                    var entity = _EquipementAppService.GetById(equipement.Id);
                    entity.CodeEquipement = equipement.CodeEquipement;
                    entity.NumSerie = equipement.NumSerie;
                    entity.NumModel = equipement.NumModel;
                    entity.Marque = equipement.Marque;
                    entity.Designation = equipement.Designation;


                    entity.Id = equipement.Id;

                    try
                    {
                        _EquipementAppService.Update(entity);
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
                _EquipementAppService.Remove(id);
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

        public ActionResult Add(Equipement_DTO obj)
        {
            if (!ModelState.IsValid)
            {

                return Json(false);

            }
            else
            {
                _EquipementAppService.Add(obj);
                return Json(true);

            }
        }
    }
}