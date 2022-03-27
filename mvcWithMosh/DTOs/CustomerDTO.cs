using mvcWithMosh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcWithMosh.DTOs
{
    public class CustomerDTO
    {
        public short Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        //[CheckAgeOfMember]
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;

        [Required]
        public bool IsSubscriber { get; set; }
        
        //public MembershipType MembershipType { get; set; }
        
        [Required]        
        public byte MembershipTypeId { get; set; }

    }
}