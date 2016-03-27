using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mts.Domain;
using Mts.Domain.Abstract;

namespace Mts.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;
        public HomeController(IProductRepository repositoryParam)
        {
            repository = repositoryParam;
        }
        public ActionResult Index()
        {
            
            return View(repository.Products.ToList());
        }

        public ViewResult ListByCategory(string category = null)
        {
            if (category != null)
                return View(repository.Products.Where(x => x.ProductTypes.Name == category).ToList<Products>());
            else
                throw new HttpException(404, "not found type of device");
        }
    }
}