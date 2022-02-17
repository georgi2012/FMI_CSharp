using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataBindingExample7
{
    public class MyValidationForAge : System.Windows.Controls.ValidationRule
    {
        private int validAge;
        public int ValidAge
        {
            get { return validAge; }
            set { validAge = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {   // parameter value holds the  data subject for validation
            int enteredAge;
            if (int.TryParse((string)value, out enteredAge) && enteredAge < validAge)
            {
                return new ValidationResult(true, null);
            }
            else
            {   // the rule passed
                return new ValidationResult(false, "Invalid Age");
            }

        }
    }
}
