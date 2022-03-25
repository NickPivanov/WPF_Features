using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WPF_ValidationRuleDemo.ValidationRules
{
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Введите корректный адрес электронной почты.");

            var validEmailRgx = new Regex(@"^[\w\.\-]+@[\w\.\-]+\.[a-z]{2,6}$");

            var email = value.ToString();
            if (!validEmailRgx.IsMatch(email))
                return new ValidationResult(false, "Введите корректный адрес электронной почты.");
            return ValidationResult.ValidResult;
        }
    }
}
