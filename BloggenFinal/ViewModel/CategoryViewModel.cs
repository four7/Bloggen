using BloggenFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggenFinal.ViewModel
{
    public class CategoryViewModel
    {
        public BloggProp bloggen { get; set; }
        public List<Categories> kategorier { get; set; }
        public Categories cats { get; set; }
        public List<BloggProp> filterLista { get; set; }
        
        public CategoryViewModel()
        {
            bloggen = new BloggProp();
            kategorier = new List<Categories>();
            cats = new Categories();
            filterLista = new List<BloggProp>();
        }

    }
}
