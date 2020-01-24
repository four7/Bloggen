using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloggenFinal.Models
{
    public partial class Categories
    {
        public string CategoryDescription { get; set; }
        [Key]
        public int Id { get; set; }

        //public enum Choices
        //{
        //    Sport,
        //    Mat,
        //    Resor
        //}

        //public List<Categories> GetCategories()
        //{
        //    List<Categories> catte = new List<Categories>();
        //    catte.Add(new Categories { CategoryDescription = Choices.Mat.ToString() });
        //    catte.Add(new Categories { CategoryDescription = Choices.Sport.ToString() });
        //    catte.Add(new Categories { CategoryDescription = Choices.Resor.ToString() });
        //    return catte;
        //}
    }
}
