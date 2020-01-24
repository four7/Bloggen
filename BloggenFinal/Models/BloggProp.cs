using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggenFinal.Models
{
    public partial class BloggProp
    {
        [ForeignKey("Id")]
        public int CategoryDescription { get; set; }

        [Required(ErrorMessage = "Din bloggpost måste ha en titel.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Din titel får ha max 50 tecken och minst 5 tecken.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Din bloggpost måste ha något innehåll.")]
        [StringLength(2000, MinimumLength = 5, ErrorMessage = "Ditt inlägg får ha max 2000 tecken och minst 5 tecken.")]
        public string Post { get; set; }
        public DateTime Date { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        

    }
}
