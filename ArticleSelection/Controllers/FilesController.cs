using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryEntity;

namespace ArticleSelection.Views.Test
{
    public class FilesController : Controller
    {
        private readonly EntityDbContext _context;
        public FilesController(EntityDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var all = _context.AllFiles.AsQueryable();
            return View(all);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Files fl)
        {
            var file = new Files
            {
                ID = Guid.NewGuid(),
                Title = fl.Title,
                Content = fl.Content,
                DateTime = fl.DateTime != null ? fl.DateTime : DateTime.Now,
                Type = fl.Type
            };
            _context.Add(file);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}