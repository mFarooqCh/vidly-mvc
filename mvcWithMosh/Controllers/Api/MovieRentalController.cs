using mvcWithMosh.DTOs;
using mvcWithMosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace mvcWithMosh.Controllers.Api
{
    public class MovieRentalController : ApiController
    {
        private readonly AppDbContext dbContext;

        public MovieRentalController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // POST: MovieRental
        [HttpPost]
        public IHttpActionResult NewMovieRental(MovieRentalDTO rentalDTO)
        {
            var customer = dbContext.Customer.Find(rentalDTO.CustomerId);
            
            var movies = dbContext.Movies.Where(m => rentalDTO.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                var rental = new MovieRental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,
                    DateReturned = DateTime.Now.AddDays(7)
                };

                dbContext.Rentals.Add(rental);
            }
            dbContext.SaveChanges();

            return Ok();
        }
    }
}