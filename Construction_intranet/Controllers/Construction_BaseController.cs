using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Construction_intranet.Controllers
{
    public class Construction_BaseController : Controller
    {
        // GET: Construction_Base
        public string GetValidationErrors()
        {
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            StringBuilder validationErrors = new StringBuilder();
            foreach (var item in allErrors)
            {
                validationErrors.Append(String.Format("{0} {1}", item.ErrorMessage, Environment.NewLine));
            }

            return validationErrors.ToString();
        }

        public string GetMessage(string type)
        {
            string errorMessage = "";
            switch (type)
            {
                case "error":
                    errorMessage = "An error occured while processing your request!";
                    break;
                case "save":
                    errorMessage = "Record has successfully saved.";
                    break;
                case "update":
                    errorMessage = "Updates on record has successfully saved.";
                    break;
                case "delete":
                    errorMessage = "Record has successfully deleted.";
                    break;
                case "already":
                    errorMessage = "Email already Exists";
                    break;
                case "unblock":
                    errorMessage = "Member has successfully unblocked.";
                    break;

                default:
                    errorMessage = "An unknown error has occured. Please contact your system administrator";
                    break;
            }

            return errorMessage;
        }

    }
}