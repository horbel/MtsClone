using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mts.Domain;
using Mts.Domain.Abstract;
using System.Data.Entity.Validation;
using System.IO;


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
                    return PartialView("ListOfBrands",repository.Brands.ToList());

                case "types":
                    return PartialView("ListOfTypes", repository.ProductTypes.ToList());
                default:
                    throw new HttpException(404, "there is no table with that name");
            }

        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file, int? id)
        {
            if(file!=null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Resources/ProductImages"), fileName);                
                file.SaveAs(path);
                path = ("~/Resources/ProductImages/" + fileName).Replace(" ", string.Empty);
                repository.SaveImage(path, id);
                TempData["UploadImage"] = "Image has been saved";
            }
        
            else
            {
                TempData["UploadImage"] = "Image hasn't been saved";
            }
            return RedirectToRoute(new { controller = "admin", action = "Edit", id = id, table = "products" });
        }

        public ViewResult Edit(int? id, string table)
        {            
            
            switch(table)
            {
                case "products":
                    {                        
                        ViewBag.Brand = new SelectList(repository.Brands, "ID", "Name");
                        ViewBag.Type = new SelectList(repository.ProductTypes, "ID", "Name");                        
                        Products product = repository.Products.FirstOrDefault(p => p.ID == id);
                        return View("EditProduct", product);
                    }
                case "brands":
                    {
                        Brands brand = repository.Brands.FirstOrDefault(b => b.ID == id);
                        return View("EditBrand", brand);
                    }
                case "types":

                    {
                        ProductTypes type = repository.ProductTypes.FirstOrDefault(t => t.ID == id);
                        return View("EditType", type);
                    }
                default:
                    throw new HttpException(404, "no table");
            }
            
        }
        [HttpPost]
        public ActionResult EditProduct(Products entity)
        {
            if(ModelState.IsValid)
            {
                
                try
                {
                    repository.Save(entity);
                    TempData["message"] = "Entity has been saved";
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        TempData["error"] += "Object: " + validationError.Entry.Entity.ToString();
                        

                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            TempData["error2"] += err.ErrorMessage;
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            else
                throw new HttpException(404, "model state is not valid");
        }

        [HttpPost]
        public ActionResult EditBrand(Brands entity)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = "Entity has been saved";
                try
                {
                    repository.Save(entity);
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        TempData["error"] += "Object: " + validationError.Entry.Entity.ToString();
                        

                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            TempData["error2"] += err.ErrorMessage;
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            else
                throw new HttpException(404, "model state is not valid");
        }

        [HttpPost]
        public ActionResult EditType(ProductTypes entity)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = "Entity has been saved";
                try
                {
                    repository.Save(entity);
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        TempData["error"] += "Object: " + validationError.Entry.Entity.ToString();


                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            TempData["error2"] += err.ErrorMessage;
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            else
                throw new HttpException(404, "model state is not valid");
        }

        [HttpPost]
        public ActionResult Delete(int? id, string table)
        {
            repository.DeleteEntity(id, table);
            return RedirectToAction("Index");
        }
    }
}