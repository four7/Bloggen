using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggenFinal.Models;
using BloggenFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BloggenFinal.Controllers
{
    public class ShowPostController : Controller
    {
        private BloggContext _context;

        //Injectar EF till controllern
        public ShowPostController(BloggContext context)
        {
            _context = context;
        }
        public IActionResult ShowPost(int Id)
        {
            var lista = new CategoryViewModel();

            var inlagg = (from s in _context.BloggProp
                          select s);

            inlagg = inlagg.Where(s => s.Id == Id);

            lista.cats.BloggProp = inlagg.ToList();
                        

            return View(lista);
        }

        //[HttpPost]
        //public IActionResult ShowPost(CategoryViewModel model)
        //{
        //    return View();
        //}
    }
}