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
    public class StockOutController : Controller
    {
        private readonly IAppMagasinService _MagasinAppService;
        private readonly IAppStockOutService _StockOutAppService;

        private readonly IAppPersonnelService _PersonnelAppService;
        private readonly IAppStockInService _StockInAppService;

        public StockOutController(IAppMagasinService MagasinAppService, IAppStockOutService StockOutAppService, IAppPersonnelService PersonnelAppService, IAppStockInService StockInAppService)
        {
            _MagasinAppService = MagasinAppService;
            _StockOutAppService = StockOutAppService;

            _PersonnelAppService = PersonnelAppService;
            _StockInAppService = StockInAppService;


        }
        // GET: StockOut
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
            var model = _StockOutAppService.GetAll();

            var model1 = _MagasinAppService.GetAll();
            model1 = model1.OrderBy(x => x.libelle);


            var model2 = _PersonnelAppService.GetAll();
            model2 = model2.OrderBy(x => x.Nom);


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

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var stockOut = _StockOutAppService.GetById(id);
            return Json(new
            {
                data = stockOut,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPiece(string mag)
        {
            //.Where(x => x.magasin == mag)

            var model1 = _StockInAppService.GetAll().Where(x => x.magasin == mag);

            model1 = model1.OrderBy(x => x.piece);






            return Json(new
            {

                status = true,
                droplist = model1

            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveData(string strStockOut)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            StockOut_DTO stockOut = serializer.Deserialize<StockOut_DTO>(strStockOut);
            bool status = false;
            string message = string.Empty;
            //add new stockOut if id = 0
            if (stockOut.Date == null)
            {
                status = false;
            }

            else
            {


                if (stockOut.Id == 0)
                {
                    int c = _StockOutAppService.GetAll().Count();

                    try
                    {
                        if (c > 0)
                        {
                            int i = _StockOutAppService.GetAll().Max(x => x.Id);
                            int j = i + 1;
                            string s = j.ToString();
                            stockOut.Ref = "SP" + s;
                        }
                        else if (c == 0) { stockOut.Ref = "EP" + "1"; }
                        _StockOutAppService.Add(stockOut);
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

                    var entity = _StockOutAppService.GetById(stockOut.Id);
                    entity.Date = stockOut.Date;

                    entity.personnel = stockOut.personnel;
                    entity.Ref = stockOut.Ref;
                    entity.magasin = stockOut.magasin;
                    entity.qte = stockOut.qte;

                    entity.observation = stockOut.observation;
                    entity.Id = stockOut.Id;

                    try
                    {
                        _StockOutAppService.Update(entity);
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
                _StockOutAppService.Remove(id);
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