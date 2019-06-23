using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace gui.Utils
{
    public class TextValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!(value is string input))
            {
                return new ValidationResult(false, Constants.CHECK_SELECTION);
            }

            if (input == string.Empty || input.Length > 40)
            {
                return new ValidationResult(false, Constants.CHECK_SELECTION);
            }

            return new ValidationResult(true, string.Empty);
        }
    }
}
