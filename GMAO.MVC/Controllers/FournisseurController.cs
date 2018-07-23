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
    public class FournisseurController : Controller
    {

        private readonly IAppFournisseurService _FournisseurAppService;
        private readonly IAppCategorieFournisseurService _CategorieFournisseurAppService;
        private readonly IAppDeviseService _DeviseAppService;

        public FournisseurController(IAppFournisseurService FournisseurAppService, IAppCategorieFournisseurService CategorieFournisseurAppService, IAppDeviseService DeviseAppService)
        {
            _FournisseurAppService = FournisseurAppService;
            _DeviseAppService = DeviseAppService;
            _CategorieFournisseurAppService = CategorieFournisseurAppService;
        }
        // GET: Fournisseur
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
            var model = _FournisseurAppService.GetAll();
            var model1 = _CategorieFournisseurAppService.GetAll();
            model1 = model1.OrderBy(x => x.Designation);

            var model2 = _DeviseAppService.GetAll();
            model2 = model2.OrderBy(x => x.Designation);


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.Code_Fournisseur)
              .Skip((page - 1) * pageSize)
              .Take(pageSize);


            return Json(new
            {
                data = model,
                total = totalRow,
                status = true,
                droplist = model1,
                droplist1 = model2
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var fournisseur = _FournisseurAppService.GetById(id);
            return Json(new
            {
                data = fournisseur,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strFournisseur)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Fournisseur_DTO fournisseur = serializer.Deserialize<Fournisseur_DTO>(strFournisseur);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (fournisseur.Code_Fournisseur == null)
            {
                status = false;
            }

            else
            {


                if (fournisseur.Id == 0)
                {

                    try
                    {
                        _FournisseurAppService.Add(fournisseur);
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

                    var entity = _FournisseurAppService.GetById(fournisseur.Id);
                    entity.Code_Fournisseur = fournisseur.Code_Fournisseur;
                    entity.Nom = fournisseur.Nom;
                    entity.Délai_confirmation_CDE = fournisseur.Délai_confirmation_CDE;
                    entity.Domaine = fournisseur.Domaine;
                    entity.observation = fournisseur.observation;
                    entity.adresse_usine = fournisseur.adresse_usine;
                    entity.pays_usine = fournisseur.pays_usine;
                    entity.ville_usine = fournisseur.ville_usine;
                    entity.ccp_usine = fournisseur.ccp_usine;
                    entity.tel_usine = fournisseur.tel_usine;
                    entity.fax_usine = fournisseur.fax_usine;
                    entity.email_usine = fournisseur.email_usine;
                    entity.adresse_facturation = fournisseur.adresse_facturation;
                    entity.Pays_F = fournisseur.Pays_F;
                    entity.Ville_F = fournisseur.Ville_F;
                    entity.ccp_F = fournisseur.ccp_F;
                    entity.téL_F = fournisseur.téL_F;
                    entity.FAX_F = fournisseur.FAX_F;
                    entity.EMAIL_F = fournisseur.EMAIL_F;
                    entity.adresse_livraison = fournisseur.adresse_livraison;
                    entity.Pays_L = fournisseur.Pays_L;
                    entity.Ville_L = fournisseur.Ville_L;
                    entity.ccP_L = fournisseur.ccP_L;
                    entity.téL_L = fournisseur.téL_L;
                    entity.FAX_l = fournisseur.FAX_l;
                    entity.EMAIL_L = fournisseur.EMAIL_L;
                    entity.Banque = fournisseur.Banque;
                    entity.Domiciliation_Bancaire = fournisseur.Domiciliation_Bancaire;
                    entity.Compte_Courant_Bancaire = fournisseur.Compte_Courant_Bancaire;
                    entity.IBAN = fournisseur.IBAN;
                    entity.code_douane = fournisseur.code_douane;
                    entity.SWIFT = fournisseur.SWIFT;
                    entity.matricule_fiscale = fournisseur.matricule_fiscale;
                    entity.escompte = fournisseur.escompte;
                    entity.nb_facture = fournisseur.nb_facture;
                    entity.Code_tva = fournisseur.Code_tva;
                    entity.nb_bl = fournisseur.nb_bl;

                    entity.Id = fournisseur.Id;

                    try
                    {
                        _FournisseurAppService.Update(entity);
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
                _FournisseurAppService.Remove(id);
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

        public ActionResult Add(Fournisseur_DTO obj)
        {
            if (ModelState.IsValid)
            {
                _FournisseurAppService.Add(obj);
                return Json(true);

            }
            else return Json(false);
        }

    }
}