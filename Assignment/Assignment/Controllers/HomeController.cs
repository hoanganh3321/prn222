using System.Diagnostics;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly FunewsManagementContext _context;
        public HomeController(FunewsManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var newsList = _context.NewsArticles
            .Where(n => n.NewsStatus == true) 
            .OrderByDescending(n => n.CreatedDate) 
            .ToList();

            return View(newsList); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
