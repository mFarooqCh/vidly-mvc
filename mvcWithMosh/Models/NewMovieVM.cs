using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcWithMosh.Models
{
    public class NewMovieVM
    {
        public Movies Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }

    }
}