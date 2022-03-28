using System;
using System.ComponentModel.DataAnnotations;

namespace mvcWithMosh.Models
{
    public class MovieRental
    {
        public int Id { get; set; }
        [Required]
        public Customers Customer { get; set; }
        [Required]
        public Movies Movie { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}