using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded   { get; set; }

        [Required]
        [Range(1,20, ErrorMessage = "The field Number In Stock must be between 1 and 20")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

    }
}