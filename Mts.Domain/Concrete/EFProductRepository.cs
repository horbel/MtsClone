using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mts.Domain.Abstract;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Mts.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        MtsDBEntities context = new MtsDBEntities();
        public IQueryable<Brands> Brands
        {
            get
            {
                return context.Brands;
            }
        }

        public IQueryable<Products> Products
        {
            get
            {
                return context.Products;
            }
        }

        public IQueryable<ProductTypes> ProductTypes
        {
            get
            {
                return context.ProductTypes;
            }
        }

        public void SaveProduct(object entity)
        {
            if (entity is Products)
            {
                Products prod = entity as Products;
                if (prod.ID == 0)
                {
                    context.Products.Add(prod);
                }
                else
                {
                    Products dbProduct = context.Products.Find(prod.ID);
                    if (dbProduct != null)
                    {
                        dbProduct.ModelName = prod.ModelName;
                        dbProduct.Price = prod.Price;
                        dbProduct.Description = prod.Description;
                        dbProduct.TypeID = prod.TypeID;
                        dbProduct.BrandID = prod.BrandID;
                    }
                }
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                              "Class: {0}, Property: {1}, Error: {2}",
                              validationErrors.Entry.Entity.GetType().FullName,
                              validationError.PropertyName,
                              validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
