using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace ONE.Classes
{
    public class Utility
    {
        public static bool IsModelValied(object x, out ModelStateDictionary e)
        {
            ValidationContext context = new ValidationContext(x, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            e = new ModelStateDictionary();
            if (!Validator.TryValidateObject(x, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    string er = result.ErrorMessage;
                    e.AddModelError(key: result.MemberNames.ToList().FirstOrDefault(), errorMessage: er);
                }
                return false;
            }
            return true;
        }
    }
}