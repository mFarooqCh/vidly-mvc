using System;
using System.ComponentModel.DataAnnotations;

namespace mvcWithMosh.Models
{
    public class CheckAgeOfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.UnKnown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.DateOfBirth == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;
            if (age < 18 )
            {
                return new ValidationResult("Customer's age should be 18 years to go on a membership.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}