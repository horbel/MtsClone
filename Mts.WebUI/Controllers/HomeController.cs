using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mts.Domain;

namespace Mts.WebUI.Controllers
{
    public class HomeController : Controller
    {
        MtsDBEntities db = new MtsDBEntities();
        public ActionResult Index()
        {
            
            return View(db.Products.ToList());
        }
    }
}