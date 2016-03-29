using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mts.Domain.Abstract;
using Mts.WebUI.Models;

namespace Mts.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;  
        public NavController(IProductRepository repositoryParam)
        {
            repository = repositoryParam;
        }   
        public PartialViewResult Menu(string category = null)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = repository.Products,
                CurrentCategory = category
            };

            ViewBag.SelectedCategory = viewModel.CurrentCategory;
            IEnumerable<string> categories = repository.ProductTypes.Select(x => x.Name);
            return PartialView(categories);
        }

      
    }
}