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

    }
}

