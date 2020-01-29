using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggenFinal.Models;
using BloggenFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace BloggenFinal.Controllers
{
    public class SearchController : Controller
    {
        private BloggContext _contexts;

        public SearchController(BloggContext contexts)
        {
            _contexts = contexts;
        }
        public IActionResult SearchPost()
        {
            var listdata = new CategoryViewModel();
            
            listdata.kategorier = _contexts.Categories.ToList();
            listdata.cats.BloggProp = _contexts.BloggProp.ToList();
            
            return View(listdata);
        }
        [HttpPost]
        public IActionResult SearchPost(CategoryViewModel model)
        {
            int sport = 1;
            int mat = 2;
            int resor = 3;

            var lista = new CategoryViewModel();

            var inlagg = (from s in _contexts.BloggProp
                          select s).ToList();

            if (!String.IsNullOrEmpty(model.bloggen.Title))
            {
                if (model.bloggen.CategoryId == sport)
                {
                    inlagg = inlagg.Where(s => s.Title.ToLower().StartsWith(model.bloggen.Title)&&s.CategoryId == sport).ToList();  
                }
                if (model.bloggen.CategoryId == mat)
                {
                    inlagg = inlagg.Where(s => s.Title.ToLower().StartsWith(model.bloggen.Title) && s.CategoryId == mat).ToList();
                }
                if (model.bloggen.CategoryId == resor)
                {
                    inlagg = inlagg.Where(s => s.Title.ToLower().StartsWith(model.bloggen.Title) && s.CategoryId == resor).ToList();
                }
                else
                {
                   inlagg = inlagg.Where(s => s.Title.ToLower().StartsWith(model.bloggen.Title)).ToList();
                }
               
            }
            if (String.IsNullOrEmpty(model.bloggen.Title) && model.bloggen.CategoryId == sport)
            {
                inlagg = inlagg.Where(s => s.CategoryId == sport).ToList();
            }
            if (String.IsNullOrEmpty(model.bloggen.Title) && model.bloggen.CategoryId == mat)
            {
                inlagg = inlagg.Where(s => s.CategoryId == mat).ToList();
            }
            if (String.IsNullOrEmpty(model.bloggen.Title) && model.bloggen.CategoryId == resor)
            {
                inlagg = inlagg.Where(s => s.CategoryId == resor).ToList();
            }

            lista.kategorier = _contexts.Categories.ToList();
            lista.cats.BloggProp = inlagg;

            return View(lista);
        }
    }
}