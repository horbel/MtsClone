using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
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

        public void Save(Products product)
        {
            if (product.ID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Products dbEntry = context.Products.Find(product.ID);
                if (dbEntry != null)
                {
                    context.Entry(dbEntry).CurrentValues.SetValues(product);
                }
            }
            context.SaveChanges();
        }
        public void Save(Brands brand)
        {
            if (brand.ID == 0)
            {
                context.Brands.Add(brand);
            }
            else
            {
                Brands dbEntry = context.Brands.Find(brand.ID);
                if (dbEntry != null)
                {
                    context.Entry(dbEntry).CurrentValues.SetValues(brand);
                }
            }
            context.SaveChanges();
        }
        public void Save(ProductTypes type)
        {
            if (type.ID == 0)
            {
                context.ProductTypes.Add(type);
            }
            else
            {
                ProductTypes dbEntry = context.ProductTypes.Find(type.ID);
                if (dbEntry != null)
                {
                    context.Entry(dbEntry).CurrentValues.SetValues(type);
                }
            }
            context.SaveChanges();
        }
        public void SaveImage(string path, int? productId)
        {
            if (path != null && productId != null)
            {
                Products dbEntry = context.Products.Find(productId);
                if (dbEntry != null)
                {
                    dbEntry.ProductImageLocation = path;
                }
            }
            context.SaveChanges();
        }

        public void DeleteEntity(int? id, string table)
        {
            try
            {
                switch (table)
                {
                    case "products":
                        context.Products.Remove(context.Products.Find(id));
                        break;
                    case "brands":
                        context.Brands.Remove(context.Brands.Find(id));
                        break;
                    case "types":
                        ProductTypes dbEntity = context.ProductTypes.Find(id);
                        context.ProductTypes.Remove(dbEntity);
                        break;
                    default:
                        break;
                }
                
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
        }

    }
}

