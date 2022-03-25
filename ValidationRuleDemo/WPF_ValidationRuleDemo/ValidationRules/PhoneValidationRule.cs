using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WPF_ValidationRuleDemo.ValidationRules
{
    public class PhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Введите корректный номер телефона.");

            var validPhoneRgx = new Regex(@"^[\+][7][\d]{10,16}$");

            var phone = value.ToString();
            if (!validPhoneRgx.IsMatch(phone))
                return new ValidationResult(false, "Введите корректный номер телефона.");
            return ValidationResult.ValidResult;
        }
    }
}
