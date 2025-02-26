using Assignment.Models;
using Assignment.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controllers
{
    public class CategoryController : Controller
    {
        private readonly FunewsManagementContext _context;
        public CategoryController(FunewsManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    CategoryDesciption = c.CategoryDesciption,
                    IsActive = c.IsActive
                }).ToListAsync();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    CategoryName = model.CategoryName,
                    CategoryDesciption = model.CategoryDesciption,
                  
                };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", await GetCategories());
        }

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var category = _context.Categories
				.Where(c => c.CategoryId == id)
				.Select(c => new CategoryViewModel
				{
					CategoryId = c.CategoryId,
					CategoryName = c.CategoryName,
					CategoryDesciption = c.CategoryDesciption,
					IsActive = c.IsActive
				})
				.FirstOrDefault();

			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(CategoryViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var category = _context.Categories.Find(model.CategoryId);
			if (category == null)
			{
				return NotFound();
			}

			category.CategoryName = model.CategoryName;
			category.CategoryDesciption = model.CategoryDesciption;
			category.IsActive = model.IsActive;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}



		[HttpPost]
        public async Task<IActionResult> Delete(short id)
        {
            var category = await _context.Categories
                .Include(c => c.NewsArticles)
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            if (category == null) return NotFound();
            if (category.NewsArticles.Any())
            {
                ModelState.AddModelError("", "Không thể xóa vì category này đang có bài viết.");
                return View("Index", await GetCategories());
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<List<CategoryViewModel>> GetCategories()
        {
            return await _context.Categories
                .Select(c => new CategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    CategoryDesciption = c.CategoryDesciption,
                    IsActive = c.IsActive
                }).ToListAsync();
        }
    }
}
