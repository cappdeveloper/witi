using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Construction_intranet.Models;
using DAL_Construction.Data;



namespace Construction_intranet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContractorController : Controller
    {
        Construction_DBEntities _entities = new Construction_DBEntities();
        Construction_BaseController _login = new Construction_BaseController();
        // GET: Contractor
        public ActionResult Index()
        {
            List<ContractorModel> model = new List<ContractorModel>();
            model = (new ContractorDB()).GetContractor();
            return View(model);
        }

        public ActionResult CreateEdit(int id=0)
        {
            ContractorModel model = new ContractorModel();
            if (id > 0)
            {
               model = (new ContractorDB()).GetContractorbyId(id);
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
        public ActionResult CreateEdit(ContractorModel model)
        {
            RequestResultModel requestModel = new RequestResultModel();
          
            int returnId = 0;
            try
            {
                model.CreatedDate = DateTime.UtcNow;
                model.ModifiedDate = DateTime.UtcNow;
                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        var vendor = _entities.tblContractors.Where(m => m.Id == model.Id).FirstOrDefault();
                        vendor.FirstName = model.FirstName;
                        vendor.Phone = model.Phone;
                        vendor.Email = model.Email;
                        vendor.Address = model.Address;
                        vendor.City = model.City;
                        vendor.CreatedDate = model.CreatedDate;
                        vendor.ModifiedDate = model.ModifiedDate;
                        vendor.Zip = model.Zip;
                        vendor.LastName = model.LastName;
                        vendor.Notes = model.Notes;
                        vendor.State = model.State;

                        _entities.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
                        _entities.SaveChanges();
                        

                        returnId = model.Id;
                    }
                    else
                    {

                        tblContractor vendor = new tblContractor();
                        vendor.FirstName = model.FirstName;
                        vendor.Phone = model.Phone;
                        vendor.Email = model.Email;
                        vendor.Address = model.Address;
                        vendor.City = model.City;
                        vendor.CreatedDate = model.CreatedDate;
                        vendor.ModifiedDate = model.ModifiedDate;
                        vendor.Zip = model.Zip;
                        vendor.LastName = model.LastName;
                        vendor.Notes = model.Notes;
                        vendor.State = model.State;
                        vendor.Isactive = true;
                        _entities.tblContractors.Add(vendor);
                        _entities.SaveChanges();

                        returnId = vendor.Id;
                    }

                    requestModel.Title = "Success!";
                    requestModel.Message = _login.GetMessage("save");
                    requestModel.InfoType =RequestResultInfoType.Success;
                    return Json(new
                    {
                        returnId = returnId,
                        NotifyType = NotifyType.PageInline,
                        Html = this.RenderPartialView(@"_RequestResultPageInlineMessage", requestModel)

                    }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    returnId = model.Id;
                    requestModel.Message =_login.GetValidationErrors();
                }
            }
            catch (Exception)
            {
                requestModel.Message =_login.GetMessage("error");
            }

            ViewBag.Action = (model.Id > 0) ? "Edit" : "Create";
          
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
        public ActionResult InActive(int id)
        {
            try
            {
                var q =_entities.tblContractors.Where (m=>m.Id == id && m.Isactive == true).SingleOrDefault();
                if (q != null)
                {
                    q.Isactive = false;
                  
                }
                _entities.Entry(q).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Active(int id)
        {
            try
            {
                var q = _entities.tblContractors.Where(m => m.Id == id && m.Isactive == false).SingleOrDefault();
                if (q != null)
                {
                    q.Isactive =true;

                }
                _entities.Entry(q).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();




                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

     
    }
}