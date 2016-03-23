using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mts.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Brands> Brands { get;}//?
        IQueryable<Products> Products { get;}
        IQueryable<ProductTypes> ProductTypes { get;}//?
    }
}
