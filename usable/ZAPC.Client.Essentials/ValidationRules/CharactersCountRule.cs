namespace ZAPC.Client.Essentials.ValidationRules
{
    using System.Globalization;
    using System.Windows.Controls;

    public class CharactersCountRule : ValidationRule
    {
        public int MaxCharCount { get; set; } = int.MaxValue;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (string.IsNullOrEmpty((string)value)) return ValidationResult.ValidResult;

                var charactersCount = ((string)value).Length;
                return charactersCount > MaxCharCount
                           ? new ValidationResult(false, $"Поле не может быть длиннее {MaxCharCount} символов")
                           : ValidationResult.ValidResult;
            }
            catch
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
