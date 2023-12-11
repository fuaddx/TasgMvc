using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok2.Contexts;

namespace Pustok2.Controllers
{

    public class ProductController1 : Controller
    {
        PustokDbContext _db { get; }
        public ProductController1(PustokDbContext db)
        {
            _db = db;
        }

        
        public IActionResult Index()
        {
            return View();
        }
        /*public async Task<IActionResult>Details(int id)
        {
            if (id == null || id <= 0) return BadRequest();
            var data = await _db.Products.Select(p => new ProductDetailVM
            {
                Discount = p.Discount,
                Category = p.Category,
                Colors = p.ProductColors.Select(p => p.Color),
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                ImageUrls = p.ProductImages.Select(p => p.ImageUrl),
                Name = p.Name,
                Quantity = p.Quantity,
                Description = p.Description,
                About = p.About,
                SellPrice = (p.SellPrice - (p.SellPrice * (decimal)p.Discount) / 100).ToString("0.##"),
            }).SingleOrDefaultAsync(p => p.Id == id);
            if (data == null) return NotFound();
            return View(data);
        }*/
    }
}
