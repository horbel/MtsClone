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
    }
}