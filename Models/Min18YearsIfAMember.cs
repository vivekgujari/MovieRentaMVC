﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentaMVC.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo || customer.MembershipTypeId == MembershipType.Unknown)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18 ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 year old to go on a membership"));
        }
    }
}