using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Construction_intranet.Models;
using DAL_Construction.Data;
using Construction_intranet.Concrete_Classes;

namespace Construction_intranet.Controllers
{
    public class EquipmentController : Controller
    {
        Construction_DBEntities oDB = new Construction_DBEntities();
        Construction_BaseController _login = new Construction_BaseController();


        // GET: Equipment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEdit(int id=0)
        {
            EquipmentModel model = new EquipmentModel();
         
            if (id > 0)
            {
                model = (new EquipmentDB()).GetEquipmentbyId(id);
                ViewBag.Action = "Edit";
            }
            else
            {
                ViewBag.Action = "Create";
            }

            ViewBag.AllEquipments = (from p in oDB.tblEquipments
                                     where p.COntractor_id==SessionManager.ContractorId
                                select new EquipmentModel
                                {
                                   id=p.id,
                                   Equipment_name=p.Equipment_name




                                }).ToList();




            return View(model);

       
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(EquipmentModel model)
        {
            RequestResultModel requestModel = new RequestResultModel();

            int returnId = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.id> 0)
                    {

                     
                        var user = oDB.tblEquipments.Where(m => m.id == model.id).FirstOrDefault();
                        user.Equipment_name = model.Equipment_name;

                        oDB.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        oDB.SaveChanges();



                        returnId = (int)model.id;
                    }
                    else
                    {
                        tblEquipment equipment = new tblEquipment();
                        equipment.Equipment_name = model.Equipment_name;
                        equipment.COntractor_id = SessionManager.ContractorId;
                       oDB.tblEquipments.Add(equipment);
                        oDB.SaveChanges();

                        returnId = (int)equipment.id;
                    }
             


                    requestModel.Title = "Success!";
                    requestModel.Message = _login.GetMessage("save");
                    requestModel.InfoType = RequestResultInfoType.Success;
                    ViewBag.AllEquipments = (from p in oDB.tblEquipments
                                             where p.COntractor_id == SessionManager.ContractorId
                                             select new EquipmentModel
                                             {
                                                 id = p.id,
                                                 Equipment_name = p.Equipment_name




                                             }).ToList();
                    return Json(new
                    {
                        returnId = returnId,
                        NotifyType = NotifyType.PageInline,
                        Html = this.RenderPartialView(@"_RequestResultPageInlineMessage", requestModel)

                    }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    returnId = (int)model.id;
                    requestModel.Message = _login.GetValidationErrors();
                }
            }
            catch (Exception)
            {
                requestModel.Message = _login.GetMessage("error");
            }

            ViewBag.Action = (model.id > 0) ? "Edit" : "Create";

            requestModel.Title = "Error!";
            requestModel.InfoType = RequestResultInfoType.ErrorOrDanger;
            return Json(new
            {
                returnId = returnId,
                NotifyType = NotifyType.PageInline,
                Html = this.RenderPartialView(@"_RequestResultPageInlineMessage", requestModel)

            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult delete(int id)
        {
            try
            {
                var q = oDB.tblEquipments.Where(m => m.id == id).SingleOrDefault();
                oDB.tblEquipments.Remove(q);
                oDB.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }


    }
}