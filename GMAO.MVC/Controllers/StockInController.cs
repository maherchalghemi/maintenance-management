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
    public class StockInController : Controller
    {
        private readonly IAppMagasinService _MagasinAppService;
        private readonly IAppStockInService _StockInAppService;
        private readonly IAppPieceRechangeService _PieceRechangeAppService;
        private readonly IAppPersonnelService _PersonnelAppService;
        private readonly IAppFournisseurService _FournisseurAppService;
        private readonly IAppEmplacementService _EmplacementAppService;
        public StockInController(IAppEmplacementService EmplacementAppService ,IAppMagasinService MagasinAppService, IAppStockInService StockInAppService, IAppPieceRechangeService PieceRechangeAppService, IAppPersonnelService PersonnelAppService, IAppFournisseurService FournisseurAppService)
        {
            _MagasinAppService = MagasinAppService;
            _StockInAppService = StockInAppService;
            _PieceRechangeAppService = PieceRechangeAppService;
            _PersonnelAppService = PersonnelAppService;
            _FournisseurAppService = FournisseurAppService;
            _EmplacementAppService = EmplacementAppService;

        }
        // GET: StockIn
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
            var model = _StockInAppService.GetAll();

            var model1 = _MagasinAppService.GetAll();
            model1 = model1.OrderBy(x => x.libelle);
            var model2 = _PieceRechangeAppService.GetAll();
            model2 = model2.OrderBy(x => x.Designation);
            var model3 = _FournisseurAppService.GetAll();
            model3 = model3.OrderBy(x => x.Nom);
            var model4 = _PersonnelAppService.GetAll();
            model4 = model4.OrderBy(x => x.Nom);


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.Id)
              .Skip((page - 1) * pageSize)
              .Take(pageSize);


            return Json(new
            {
                data = model,
                total = totalRow,
                status = true,
                droplist = model1,
                droplist1 = model2,
                droplist2 = model3,
                droplist3 = model4,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var stockIn = _StockInAppService.GetById(id);
            return Json(new
            {
                data = stockIn,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEmp(string mag)
        {
            //.Where(x => x.magasin == mag)

            var model1 = _EmplacementAppService.GetAll().Where(x => x.magasin == mag);

            model1 = model1.OrderBy(x => x.Designation);






            return Json(new
            {

                status = true,
                droplist = model1

            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveData(string strStockIn)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            StockIn_DTO stockIn = serializer.Deserialize<StockIn_DTO>(strStockIn);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if (stockIn.Date == null)
            {
                status = false;
            }

            else
            {


                if (stockIn.Id == 0)
                {
                    int c = _StockInAppService.GetAll().Count();

                    try
                    {
                        if (c > 0) { 
                        int i = _StockInAppService.GetAll().Max(x => x.Id);
                        int j = i + 1;
                        string s = j.ToString();
                        stockIn.Ref = "EP"+s;
                        }
                        else if (c==0){ stockIn.Ref = "EP"+"1"; }
                        _StockInAppService.Add(stockIn);
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
                   
                    var entity = _StockInAppService.GetById(stockIn.Id);
                    entity.Date = stockIn.Date;
                    entity.fournisseur = stockIn.fournisseur;
                    entity.personnel = stockIn.personnel;
                    entity.Ref = stockIn.Ref;
                    entity.magasin = stockIn.magasin;
                    entity.qte = stockIn.qte;
                    entity.prix = stockIn.prix;
                    entity.observation = stockIn.observation;
                    entity.Id = stockIn.Id;

                    try
                    {
                        _StockInAppService.Update(entity);
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
                _StockInAppService.Remove(id);
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