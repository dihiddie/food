namespace ZAPC.Client.Essentials.ValidationRules
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;

    public class NoNegativeNumbersRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var valueAsString = (string)value;
            if (string.IsNullOrEmpty(valueAsString)) return ValidationResult.ValidResult;

            try
            {
                if (((string)value).Length > 0)
                {
                    int val = int.Parse(valueAsString);
                    if (val < 0) return new ValidationResult(false, "Значение в данном поле не может быть отрицательным");
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Входная строка имела неверный формат");
            }

            return ValidationResult.ValidResult;
        }
    }
}
