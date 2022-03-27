using System;
using System.ComponentModel.DataAnnotations;

namespace mvcWithMosh.Models
{
    public class Customers
    {
        public short Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.DateTime)]
        [CheckAgeOfMember]
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;

        [Required]
        public bool IsSubscriber { get; set; }

        public MembershipType MembershipType { get; set; }
        
        [Required]
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}