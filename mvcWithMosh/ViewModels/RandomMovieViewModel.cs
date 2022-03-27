using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcWithMosh.Models;

namespace mvcWithMosh.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movies Movie { get; set; }
        public List<Customers> Customer { get; set; }
    }
}