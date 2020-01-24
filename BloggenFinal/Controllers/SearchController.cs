using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggenFinal.Models;
using BloggenFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
            //List<BloggProp> listdata = _contexts.BloggProp
            //    .Select(bg => new BloggProp()
            //    {
            //       Id = bg.Id,
            //       Title = bg.Title,
            //       Post = bg.Post,
            //       Date = bg.Date,
            //       CategoryDescription = bg.CategoryDescription
            //    }).ToList();
            var listdata = new CategoryViewModel();

             listdata.bloggen. = _contexts.BloggProp.ToList();

            return View(listdata);
        }
        [HttpPost]
        public IActionResult SearchPost(BloggProp titel)
        {

            return View();
        }
    }
}