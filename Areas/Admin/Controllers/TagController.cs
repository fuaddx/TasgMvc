using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pustok2.Contexts;
using Pustok2.Models;
using Pustok2.ViewModel.TagVm;

namespace Pustok2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        PustokDbContext _pustokDbContext;

        public TagController(PustokDbContext pustokDbContext)
        {
            _pustokDbContext = pustokDbContext;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Tag> tags = await _pustokDbContext.Tags.ToListAsync();

            IEnumerable<ListTagVm> tags_vm = tags.Select(tag => new ListTagVm() { Id = tag.Id, Title = tag.Title });

            return View(tags_vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTagVm createTagVm)
        {
            Tag tag = new Tag()
            {
                Id = Guid.NewGuid(),
                Title = createTagVm.Title
            };

            EntityEntry<Tag> entityEntry = await _pustokDbContext.Tags.AddAsync(tag);

            int result = await _pustokDbContext.SaveChangesAsync();

            return Redirect(nameof(Index));
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTagVm updateTagVm)
        {
            Tag tag = new Tag()
            {
                Id = updateTagVm.Id,
                Title = updateTagVm.Title,
            };

            EntityEntry<Tag> entityEntry = _pustokDbContext.Tags.Update(tag);
            int result = await _pustokDbContext.SaveChangesAsync();

            return Redirect(nameof(Index));
        }
    }
}
