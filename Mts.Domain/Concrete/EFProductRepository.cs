using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mts.Domain.Abstract;

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
    }
}
