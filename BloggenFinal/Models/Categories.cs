using System;
using System.Collections.Generic;

namespace BloggenFinal.Models
{
    public partial class Categories
    {
        public Categories()
        {
            BloggProp = new HashSet<BloggProp>();
        }

        public int Id { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<BloggProp> BloggProp { get; set; }
    }
}
