using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_Construction.Data;
using Construction_intranet.Models;
using Construction_intranet.Concrete_Classes;

namespace Construction_intranet.Controllers
{
    public class SubContractorController : Controller
    {
        // GET: SubContractor
        Construction_DBEntities oDB = new Construction_DBEntities();
        Construction_BaseController _login = new Construction_BaseController();

        //Get User Data
        public ActionResult Index()
        {
            List<SUbcontractorModel> oUsers = new List<SUbcontractorModel>();
            oUsers = (new SUbcontractorDB()).GetSubcontractor();
            return View(oUsers);

        }
        public ActionResult CreateEdit(int id = 0)
        {
            SUbcontractorModel model = new SUbcontractorModel();
            if (id > 0)
            {
              model = (new SUbcontractorDB()).GetSUbcontractorbyId(id);
                ViewBag.Action = "Edit";
            }
            else
            {
                ViewBag.Action = "Create";
            }


                return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(SUbcontractorModel model)
        {
            RequestResultModel requestModel = new RequestResultModel();

            int returnId = 0;
            try
            {
                model.Added = DateTime.UtcNow;
                if (ModelState.IsValid)
                {
                    if (model.id > 0)
                    {

                        var user = oDB.tbl_sub_contractor.Where(m => m.id == model.id).FirstOrDefault();
                        user.Name = model.Name;
                        user.Email = model.Email;
                        user.Address = model.Address;
                        user.Contact = model.Contact;
                        user.Phone = model.Phone;
                        user.Fax = model.Fax;
                        user.Added = model.Added;
                        

                        oDB.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        oDB.SaveChanges();



                        returnId = (int)model.id;
                    }
                    else
                    {
                       

                        tbl_sub_contractor user = new tbl_sub_contractor();
                        user.Name = model.Name;
                        user.Email = model.Email;
                        user.Address = model.Address;
                        user.Contact = model.Contact;
                        user.Phone = model.Phone;
                        user.Fax = model.Fax;
                        user.Added = model.Added;
                        user.Contractorid = SessionManager.ContractorId;
                        oDB.tbl_sub_contractor.Add(user);
                        oDB.SaveChanges();

                        returnId = (int)user.id;
                    }

                    requestModel.Title = "Success!";
                    requestModel.Message = _login.GetMessage("save");
                    requestModel.InfoType = RequestResultInfoType.Success;
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


    }
}