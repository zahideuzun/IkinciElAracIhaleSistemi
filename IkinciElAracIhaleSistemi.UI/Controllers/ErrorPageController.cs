﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkinciElAracIhaleSistemi.UI.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult Error401()
        {
	        return View();
        }
	}
}