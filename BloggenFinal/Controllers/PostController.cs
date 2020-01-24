using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggenFinal.Models;
using BloggenFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static BloggenFinal.Models.Categories;

namespace BloggenFinal.Controllers
{
    public class PostController : Controller
    {
        private BloggContext _context;

        //Injectar EF till controllern
        public PostController(BloggContext context)
        {
            _context = context;
        }
        public IActionResult CreatePost()
        {
            var list = _context.Categories.ToList();

            CategoryViewModel modde = new CategoryViewModel();
            modde.kategorier = list;
            modde.bloggen = new BloggProp();
            return View(modde);
        }
        

        [HttpPost]
        public IActionResult CreatePost(CategoryViewModel titel)
        {
            if(ModelState.IsValid)
            {
                DateTime tiden = DateTime.Now;
                titel.bloggen.Date = tiden;

                _context.BloggProp.Add(titel.bloggen);
                _context.SaveChanges();

                TempData["message"] = "Inlägg sparat.";

                ModelState.Clear();
                return RedirectToAction("CreatePost");
            }
            else
            {
                titel.kategorier = _context.Categories.ToList();
                return View(titel);
            }
            
        }
    }
}