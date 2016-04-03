using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mts.Domain;
using Mts.Domain.Abstract;

namespace Mts.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repositoryParam)
        {
            repository = repositoryParam;
        }
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        [HttpPost]
        public PartialViewResult List(string table)
        {
            switch (table)
            {
                case "products":
                    return PartialView("ListOfProducts", repository.Products.ToList());

                case "brands":
                    return PartialView(repository.Brands.ToList());

                case "types":
                    return PartialView(repository.ProductTypes.ToList());
                default:
                    throw new HttpException(404, "there is no table with that name");
            }

        }

        public ActionResult Edit(int? id, string table)
        {
            if(table=="products")
            {
                Products product = repository.Products.FirstOrDefault(p => p.ID == id);
                return View(product);
            }
            else
                throw new HttpException(404, "no table");
        }
    }
}