namespace ZAPC.Client.Essentials.ValidationRules
{
    using System.Globalization;
    using System.Windows.Controls;

    public class MandatoryRule : ValidationRule
    {
        public string Name { get; set; } = "Поле";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string)value))
                return new ValidationResult(false, $"{Name} обязательно для заполнения");
            return ValidationResult.ValidResult;
        }
    }
}
