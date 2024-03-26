using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission11_Aken.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace Mission11_Aken.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BookstoreContext _context;
    
    public HomeController(ILogger<HomeController> logger, BookstoreContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index(int page = 1)
    {
        int pageSize = 10;
        var books = _context.Books.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        
        // Additional data needed for pagination
        var totalBooks = _context.Books.Count();
        var totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);
        
        ViewBag.TotalPages = totalPages;
        ViewBag.CurrentPage = page;
        
        return View(books);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}