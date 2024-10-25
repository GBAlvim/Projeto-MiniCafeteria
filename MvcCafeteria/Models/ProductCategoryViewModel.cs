using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcCafeteria.Models
{
    public class ProductCategoryViewModel
    {
        public List<Product>? Products { get; set; }
        public SelectList? Categories { get; set; }
        public string? SelectedCategory { get; set; } // Renomeado para refletir melhor seu uso
        public string? SearchString { get; set; }
    }
}
