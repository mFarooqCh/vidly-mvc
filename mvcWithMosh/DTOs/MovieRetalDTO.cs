using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcWithMosh.DTOs
{
    public class MovieRentalDTO
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}