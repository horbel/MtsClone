using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mts.Domain;

namespace Mts.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Products> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}