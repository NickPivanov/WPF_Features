using System.Globalization;
using System.Net;
using System.Windows.Controls;

namespace WPF_ValidationRules.ValidationRules
{
    public class IPAddressValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (IPAddress.TryParse(value.ToString(), out IPAddress address))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "IP addres is invalid");
        }
    }
}
