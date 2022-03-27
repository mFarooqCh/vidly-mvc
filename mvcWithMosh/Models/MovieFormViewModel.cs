using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcWithMosh.Models
{
    public class MovieFormViewModel // known as pure view model
    {
        public short? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 100)]//ErrorMessage ="Number in stock must be between 1 and 100"
        public int? NumInStock { get; set; }

        public string Title
        {
            get
            {
                return Id!=0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}