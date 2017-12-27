using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var isValid = DateTime.TryParseExact(
                Convert.ToString(value),
                "dd MMMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out DateTime result
            );
            return (isValid && result > DateTime.Now);
        }
    }

    public class ValideTime : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var isValid = DateTime.TryParseExact(
                Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out DateTime result
            );
            return (isValid);
        }
    }
}