using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieBook.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Actors { get; set; }
        [Required]
        public string Producer { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Writer { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int Ratings { get; set; }
        public bool TrendingStatus { get; set; }
    }
}