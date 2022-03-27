using System;
using System.ComponentModel.DataAnnotations;

namespace mvcWithMosh.DTOs
{
    public class MoviesDTO
    {
        public short Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        //[Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        //[Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        //[Display(Name = "Added On")]
        public DateTime DateAdded { get; set; }

        [Required]
        //[Display(Name = "Number In Stock")]
        [Range(1, 100)]//ErrorMessage ="Number in stock must be between 1 and 100"
        public int NumInStock { get; set; }
    }
}