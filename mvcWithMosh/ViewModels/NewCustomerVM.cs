using mvcWithMosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcWithMosh.ViewModels
{
    public class NewCustomerVM
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customers Customer{ get; set; }
    }
}