using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCafeteria.Data;
using MvcCafeteria.Models;

namespace MvcCafeteria.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CafeteriaContext _context;

        public ProductsController(CafeteriaContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string productCategory, string searchString)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'CafeteriaContext.Product' is null.");
            }

            // Consulta para obter categorias distintas
            IQueryable<string> categoryQuery = from p in _context.Product
                                               orderby p.Category
                                               select p.Category;

            var products = from p in _context.Product
                           select p;

            // Filtro por nome do produto
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            // Filtro por categoria
            if (!string.IsNullOrEmpty(productCategory))
            {
                products = products.Where(x => x.Category.Equals(productCategory));
            }

            var productCategoryVM = new ProductCategoryViewModel
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync(), productCategory),
                Products = await products.ToListAsync(),
                SelectedCategory = productCategory, // Categoria selecionada
                SearchString = searchString // String de busca
            };
            
            return View(productCategoryVM);
        }

        // Outros métodos (Details, Create, Edit, Delete) permanecem inalterados...
    }
}
