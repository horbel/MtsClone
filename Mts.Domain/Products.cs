//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mts.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    public partial class Products
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Nullable<int> TypeID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Nullable<int> BrandID { get; set; }
        public decimal Price { get; set; }
        [Display(Name ="Model")]
        public string ModelName { get; set; }
        public string Description { get; set; }
        [HiddenInput(DisplayValue =false)]
        public string ProductImageLocation { get; set; }
    
        public virtual Brands Brands { get; set; }
        public virtual ProductTypes ProductTypes { get; set; }
    }
}
