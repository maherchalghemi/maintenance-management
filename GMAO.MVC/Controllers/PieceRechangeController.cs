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
    public class PieceRechangeController : Controller
    {
        private readonly IAppPieceRechangeService _PieceRechangeAppService;
        private readonly IAppCategoriePieceRechangeService _CategoriePieceRechangeAppService;
        public PieceRechangeController(IAppPieceRechangeService PieceRechangeAppService, IAppCategoriePieceRechangeService CategoriePieceRechangeAppService)
        {
            _PieceRechangeAppService = PieceRechangeAppService;
            _CategoriePieceRechangeAppService = CategoriePieceRechangeAppService;

        }
        // GET: PieceRechange
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
            var model = _PieceRechangeAppService.GetAll();

            var model1 = _CategoriePieceRechangeAppService.GetAll();
            model1 = model1.OrderBy(x => x.Designation);


            int totalRow = model.Count();

            model = model.OrderByDescending(x => x.CodePiece)
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
            var pieceRechange = _PieceRechangeAppService.GetById(id);
            return Json(new
            {
                data = pieceRechange,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strPieceRechange)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            PieceRechange_DTO pieceRechange = serializer.Deserialize<PieceRechange_DTO>(strPieceRechange);
            bool status = false;
            string message = string.Empty;
            //add new employee if id = 0
            if ((pieceRechange.CodePiece == null) || (pieceRechange.Designation == null))
            {
                status = false;
            }

            else
            {


                if (pieceRechange.Id == 0)
                {

                    try
                    {
                        _PieceRechangeAppService.Add(pieceRechange);
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

                    var entity = _PieceRechangeAppService.GetById(pieceRechange.Id);
                    entity.CodePiece = pieceRechange.CodePiece;
                    entity.Designation = pieceRechange.Designation;
                    entity.Etat_Pice = pieceRechange.Etat_Pice;
                    entity.CodeBarre = pieceRechange.CodeBarre;
                    entity.CodeBarreFab = pieceRechange.CodeBarreFab;
                    entity.CodeCatgorie = pieceRechange.CodeCatgorie;
                    entity.Description = pieceRechange.Description;
                    entity.code_Fournisseur = pieceRechange.code_Fournisseur;
                    entity.unité = pieceRechange.unité;
                    entity.QteReappro = pieceRechange.QteReappro;
                    entity.stock_scurit = pieceRechange.stock_scurit;
                    entity.PrixHT = pieceRechange.PrixHT;
                    entity.Id = pieceRechange.Id;

                    try
                    {
                        _PieceRechangeAppService.Update(entity);
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
                _PieceRechangeAppService.Remove(id);
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

        public ActionResult Add(PieceRechange_DTO obj)
        {
            if (!ModelState.IsValid)
            {

                return Json(false);

            }
            else
            {
                _PieceRechangeAppService.Add(obj);
                return Json(true);

            }
        }
    }
}