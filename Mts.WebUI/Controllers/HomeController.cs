using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mts.Domain;
using Mts.Domain.Abstract;
using Mts.WebUI.Models;

namespace Mts.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;
        public HomeController(IProductRepository repositoryParam)
        {
            repository = repositoryParam;
        }
        public ActionResult Index(string search)
        {
            if (search != null)
            {
                var results = repository.Products.Where(x => x.ModelName.StartsWith(search));
                if(results.Count()==0)
                {
                    results = repository.Products.Where(x => x.Brands.Name.StartsWith(search));
                }
                return View("SearchResults", results.ToList());
            }

            return View("Index", repository.Products.ToList());
        }

        public ViewResult ListByCategory(string category = null)
        {
            
            if (category != null)
            {
                return View(repository.Products.Where(x => x.ProductTypes.Name == category).ToList<Products>());
            }
                
            else
                throw new HttpException(404, "not found type of device");
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            // NEED TO REALIZE!!!!!!!!!!!!!!!!!!!!!!!//
            return View();
        }
    }
}