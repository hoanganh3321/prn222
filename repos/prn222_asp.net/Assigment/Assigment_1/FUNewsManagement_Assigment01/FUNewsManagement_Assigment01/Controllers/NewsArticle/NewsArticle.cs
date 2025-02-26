using FUNewsManagement_Assigment01.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FUNewsManagement_Assigment01.Views.Shared.Components.StaffAction
{
    public class NewsArticle : Controller
    {
        private readonly FunewsManagementContext _context;
        public NewsArticle(FunewsManagementContext context)
        {   
            _context = context;
        }

        [Authorize(Roles = "Staff,Admin")]
        public IActionResult Index(int? id)
        {
            var newsArticle = _context.NewsArticles.Include(n => n.Category).ToList();
            return View(newsArticle);
        }

        [Authorize(Roles = "Staff,Admin")]
        public IActionResult Create()
        {
            var category = _context.Categories.ToList();
            ViewBag.Category = category;
            return View();
        }

        [Authorize(Roles = "Staff,Admin")]
        public IActionResult Edit()
        {
            var category = _context.Categories.ToList();
            ViewBag.Category = category;
            return View();
        }

        [Authorize(Roles = "Staff,Admin")]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsArticle = _context.NewsArticles
                .Include(n => n.Category)        // Load Category
                .Include(n => n.CreatedBy)       // Load Author
                .FirstOrDefault(n => n.NewsArticleId == id.ToString());

            if (newsArticle == null)
            {
                return NotFound();
            }

            return View(newsArticle);  // Truyền model vào view
        }


        [Authorize(Roles = "Staff,Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsArticle = _context.NewsArticles
                .Include(n => n.Category)        // Load Category
                .Include(n => n.CreatedBy)       // Load Author
                .FirstOrDefault(n => n.NewsArticleId == id.ToString());

            if (newsArticle == null)
            {
                return NotFound();
            }

            return View(newsArticle);  // Truyền model vào view
        }
    }
}
