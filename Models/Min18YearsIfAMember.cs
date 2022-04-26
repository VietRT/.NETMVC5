using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //gives access to containing class, Customer in this case
            var customer = (Customer)validationContext.ObjectInstance;

            //0 means user has not selected membershiptype, 0 is default value for numeric properties
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)//we don't care about age if Pay as You Go
            {
                return ValidationResult.Success;
            }

            if(customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer must be 18 years or older to be on a membership.");
        }
    }
}