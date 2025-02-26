using System;
using Assignment.Models;
using Assignment.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class NewsController : Controller
{
    private readonly FunewsManagementContext _context;

    public NewsController(FunewsManagementContext context)
    {
        _context = context;
    }

    // Kiểm tra quyền truy cập cho các hành động cần bảo vệ
    private bool HasEditDeletePermission()
    {
        var accountId = HttpContext.Session.GetInt32("AccountId");
        return accountId == 1 || accountId == 2; // Chỉ có accountId = 1 hoặc 2 mới có quyền
    }

    [AllowAnonymous]
    public IActionResult Details(string id)
    {
        var news = _context.NewsArticles
            .Include(n => n.Category)
            .FirstOrDefault(n => n.NewsArticleId == id);

        if (news == null)
        {
            return NotFound();
        }

        return View(news);
    }

    public IActionResult Index()
    {
        //if (!HasEditDeletePermission())
        //{
        //    return RedirectToAction("Details", new { id = "default" }); // Chuyển hướng đến trang Details nếu không có quyền
        //}

        var newsList = _context.NewsArticles
            .Select(n => new NewsArticleViewModel
            {
                NewsArticleId = n.NewsArticleId,
                NewsTitle = n.NewsTitle,
                Headline = n.Headline,
                CreatedDate = n.CreatedDate,
                NewsContent = n.NewsContent,
                NewsStatus = n.NewsStatus,
                CategoryId = n.CategoryId,
                CategoryName = n.Category != null ? n.Category.CategoryName : "Chưa phân loại"
            })
            .ToList();

        return View(newsList);
    }

    //  [Authorize]
    public IActionResult Create()
    {
        //if (!HasEditDeletePermission())
        //{
        //    return RedirectToAction("Details", new { id = "default" }); // Nếu không có quyền, chuyển hướng đến chi tiết
        //}
        // Lấy danh sách chuyên mục từ database
        var categories = _context.Categories
            .Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

        // Truyền danh sách chuyên mục xuống View thông qua ViewBag
        ViewBag.Categories = categories;

        return View();

    }

    [HttpPost]
    //   [Authorize]
    public IActionResult Create(NewsArticleViewModel model)
    {
        //if (!HasEditDeletePermission())
        //{
        //    return RedirectToAction("Details", new { id = "default" }); // Nếu không có quyền, chuyển hướng đến chi tiết
        //}

        //if (!ModelState.IsValid)
        //{
        //    return View(model);
        //}
            var latestArticle = _context.NewsArticles
        .OrderByDescending(c => c.CreatedDate)
        .FirstOrDefault();

        var currentId = latestArticle?.NewsArticleId;

        var newsArticle = new NewsArticle
        {
            NewsArticleId = currentId + 1,
            NewsTitle = model.NewsTitle,
            Headline = model.Headline,
            NewsContent = model.NewsContent,
            CreatedDate = DateTime.Now,
            NewsStatus = model.NewsStatus ?? true,
            CategoryId = model.CategoryId
        };

        _context.NewsArticles.Add(newsArticle);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    //  [Authorize]
    public IActionResult Edit(string id)
    {
        //if (!HasEditDeletePermission())
        //{
        //    return RedirectToAction("Details", new { id = id }); // Nếu không có quyền, chuyển hướng đến chi tiết bài viết
        //}
        var news = _context.NewsArticles
            .Where(n => n.NewsArticleId == id)
            .Select(n => new NewsArticleViewModel
            {
                NewsArticleId = n.NewsArticleId,
                NewsTitle = n.NewsTitle,
                Headline = n.Headline,
                CreatedDate = n.CreatedDate,
                NewsContent = n.NewsContent,
                NewsStatus = n.NewsStatus,
                CategoryId = n.CategoryId,
               
            })
            .FirstOrDefault();

        if (news == null)
        {
            return NotFound();
        }

        ViewBag.Categories = _context.Categories
        .Select(c => new SelectListItem
        {
            Value = c.CategoryId.ToString(),
            Text = c.CategoryName
        })
        .ToList();

        return View(news);

    }

    [HttpPost]
    //  [Authorize]
    public IActionResult Edit(NewsArticleViewModel model)
    {
        //if (!HasEditDeletePermission())
        //{
        //    return RedirectToAction("Details", new { id = model.NewsArticleId }); // Nếu không có quyền, chuyển hướng đến chi tiết
        //}

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var newsArticle = _context.NewsArticles.Find(model.NewsArticleId);
        if (newsArticle == null)
        {
            return NotFound();
        }

        newsArticle.NewsTitle = model.NewsTitle;
        newsArticle.Headline = model.Headline;
        newsArticle.NewsContent = model.NewsContent;
        newsArticle.NewsStatus = model.NewsStatus;
        newsArticle.CategoryId = model.CategoryId;
        newsArticle.ModifiedDate = DateTime.Now;

        _context.NewsArticles.Update(newsArticle);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    //  [Authorize]
    //public IActionResult Delete(string id)
    //{
    //    //if (!HasEditDeletePermission())
    //    //{
    //    //    return RedirectToAction("Details", new { id = id }); // Nếu không có quyền, chuyển hướng đến chi tiết
    //    //}
    //   //var deleteTag=_context.NewsTags.FirstOrDefault(c=>c.NewsArticleId == id);
    //   // if (deleteTag == null) return NotFound();
    //   // else
    //   // {
    //      //  _context.NewsTags.Remove(deleteTag);
    //        var news = _context.NewsArticles.Find(id);
    //        if (news == null) return NotFound();

    //        _context.NewsArticles.Remove(news);
    //        _context.SaveChanges();
    //        return RedirectToAction(nameof(Index));

    //}
    public ActionResult Delete(string? id)
    {
        var news = _context.NewsArticles.Find(id);
        if (news == null)
        {
            return NotFound();
        }

        // Xóa bản ghi trong bảng trung gian bằng SQL thuần
        _context.Database.ExecuteSqlRaw("DELETE FROM NewsTag WHERE NewsArticleId = {0}", id);

        // Xóa NewsArticle
        _context.NewsArticles.Remove(news);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }


}
