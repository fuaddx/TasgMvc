using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok2.Contexts;
using Pustok2.ViewModel.ColorVM;


namespace Pustok2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        PustokDbContext _db { get; }
        public ColorController(PustokDbContext db)
        {
            _db = db;
        }        
        public async Task<IActionResult> Index()
        {
            return View(await _db.Color.Select(c=>new ColorListItemVM
            {
                Id=c.Id,
                Name=c.Name,
                HexCode =c.HexCode
            }).ToListAsync());
        }
        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(ColorCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _db.Color.AddAsync(new Models.Color
            {
                Name = vm.Name,
                HexCode = vm.HexCode.Substring(1)
        });
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
