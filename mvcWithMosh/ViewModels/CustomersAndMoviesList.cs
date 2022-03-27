using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcWithMosh.Models;
namespace mvcWithMosh.ViewModels
{
    public class CustomersAndMoviesList
    {
        public List<Movies> movie { get; set; }
        public List<Customers> customer { get; set; }
    }

}