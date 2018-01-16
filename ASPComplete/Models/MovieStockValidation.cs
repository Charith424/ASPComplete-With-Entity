using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPComplete.Models
{
    public class MovieStockValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Movie = (Movie)validationContext.ObjectInstance;
            if (Movie.Id==0) {
                return ValidationResult.Success;
            }
            if (Movie.Stock > 0 && Movie.Stock <= 20) {
                return ValidationResult.Success;
            }else
            {
                return new ValidationResult("Stock must be between 0 and 20");
            }

          
               
        }



    }
}