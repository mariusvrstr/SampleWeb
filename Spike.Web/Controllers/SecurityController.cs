﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spike.Web.Models;

namespace Spike.Web.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrossSiteScripting()
        {
            var model = new DangerousModel
            {
                DangerousHTMLCode = CodeGenerator.GetDangerousHtmlString(),
                DangerousSQLCode = CodeGenerator.GetDangerousSqlString(),
                DangerousJavaScript = CodeGenerator.GetDangerousJavaScriptString()
            };

            return View(model);
        }

        public JsonResult GetDangerousCode()
        {
            var model = new DangerousModel
            {
                DangerousHTMLCode = CodeGenerator.GetDangerousHtmlString(),
                DangerousSQLCode = CodeGenerator.GetDangerousSqlString(),
                DangerousJavaScript = CodeGenerator.GetDangerousJavaScriptString()
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDangerousReplacementCode()
        {
            var model = new DangerousModel
            {
                DangerousHTMLCode = CodeGenerator.GetDangerousHtmlString(),
                DangerousSQLCode = CodeGenerator.GetDangerousSqlString(),
                DangerousJavaScript = CodeGenerator.GetDangerousJavaScriptString()
            };

            return PartialView("_DangerousReplacement", model);
        }
    }
}