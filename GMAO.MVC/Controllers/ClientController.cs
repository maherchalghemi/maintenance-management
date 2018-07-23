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
    public class ClientController : Controller
    {
        private readonly IAppClientService _ClientAppService;
        private readonly IAppCategorieClientService _CategorieClientAppService;
        private readonly IAppDeviseService _DeviseAppService;
        public ClientController(IAppClientService ClientAppService, IAppCategorieClientService CategorieClientAppService, IAppDeviseService DeviseAppService)
        {
            _ClientAppService = ClientAppService;
            _DeviseAppService = DeviseAppService;
            _CategorieClientAppService = CategorieClientAppService;
        }
        // GET: Client
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
            var model = _ClientAppService.GetAll();
            var model1 = _CategorieClientAppService.GetAll();
            model1 = model1.OrderBy(x => x.Designation);

            var model2 = _DeviseAppService.GetAll();
            model2 = model2.OrderBy(x => x.Designation);


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.CodeInterne)
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
            var client = _ClientAppService.GetById(id);
            return Json(new
            {
                data = client,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strClient)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Client_DTO client = serializer.Deserialize<Client_DTO>(strClient);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (client.CodeInterne == null)
            {
                status = false;
            }

            else
            {


                if (client.Id == 0)
                {

                    try
                    {
                        _ClientAppService.Add(client);
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

                    var entity = _ClientAppService.GetById(client.Id);
                    entity.Banque = client.Banque;
                    entity.observation = client.observation;
                    entity.nb_bl = client.nb_bl;
                    entity.NCompte = client.NCompte;
                    entity.MatriculeFiscal = client.MatriculeFiscal;
                    entity.CodeInterne = client.CodeInterne;
                    entity.NomContact = client.NomContact;
                    entity.Email = client.Email;
                    entity.EmailF = client.EmailF;
                    entity.Tel = client.Tel;
                    entity.TelF = client.TelF;
                    entity.Domiciliation = client.Domiciliation;
                    entity.Adresse1 = client.Adresse1;
                    entity.Adresse2 = client.Adresse2;
                    entity.nbFacture = client.nbFacture;
                    entity.delaiLiv = client.delaiLiv;
                    entity.escompte = client.escompte;
                    entity.Fax = client.Fax;
                    entity.FaxF = client.FaxF;
                    entity.IBAN = client.IBAN;
                    entity.SWIFT = client.SWIFT;
                    entity.RefFour = client.RefFour;
                    entity.siret = client.siret;

                    entity.codeDouane = client.codeDouane;

                    entity.codeTVA = client.codeTVA;

                    entity.VILLE = client.VILLE;
                    entity.VILLEF = client.VILLEF;
                    entity.CCP = client.CCP;
                    entity.CCPF = client.CCPF;

                    entity.Id = client.Id;

                    try
                    {
                        _ClientAppService.Update(entity);
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
                _ClientAppService.Remove(id);
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

        public ActionResult Add(Client_DTO obj)
        {
            if (!ModelState.IsValid)
            {
               
                return Json(false);

            }
            else
            {
                _ClientAppService.Add(obj);
                return Json(true);

            }
        }
    }
}