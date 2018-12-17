namespace ZAPC.Client.Essentials.ValidationRules
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Controls;
    using System.Windows.Data;

    using ValidationResult = System.Windows.Controls.ValidationResult;

    public class ValidationFromAttributeRule : ValidationRule
    {
        protected ValidationAttribute[] ValidationAttributes { get; private set; }

        protected object Value { get; private set; }

        protected CultureInfo CultureInfo { get; private set; }

        private string Name { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo, BindingExpressionBase owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            if (!(owner is BindingExpression bindingExpression))
                throw new ArgumentException($"Parameter is not '{typeof(BindingExpression).FullName}'", nameof(owner));

            if (bindingExpression.DataItem == null)
                throw new ArgumentNullException(nameof(bindingExpression.DataItem));

            if (string.IsNullOrWhiteSpace(bindingExpression.ParentBinding?.Path?.Path))
                throw new ArgumentException(
                    @"Value is null or white space",
                    nameof(bindingExpression.ParentBinding.Path.Path));

            var dataItem = bindingExpression.DataItem;
            var pathArray = bindingExpression.ParentBinding?.Path?.Path.Split('.');

            var attributeSource = dataItem.GetType().GetProperty(pathArray[0]);
            attributeSource = pathArray.Skip(1).Aggregate(
                attributeSource,
                (current, propertyName) => current?.PropertyType.GetProperty(propertyName));

            if (attributeSource == null)
                throw new Exception(
                    $"Could not find property. Data item: {dataItem.GetType().Name}, path: {string.Join(".", pathArray)}");

            ValidationAttributes = attributeSource.GetCustomAttributes<ValidationAttribute>()
                .Where(x => !(x is RequiredAttribute)).ToArray();

            if (ValidationAttributes.Length < 1) return ValidationResult.ValidResult;

            Name = attributeSource.GetCustomAttributes<DescriptionAttribute>().SingleOrDefault()?.Description
                   ?? attributeSource.GetCustomAttributes<DisplayNameAttribute>().SingleOrDefault()?.DisplayName
                   ?? string.Empty;

            return base.Validate(value, cultureInfo, owner);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value?.ToString())) return ValidationResult.ValidResult;

            Value = value;
            CultureInfo = cultureInfo;

            try
            {
                return Validate() ? ValidationResult.ValidResult
                           : new ValidationResult(
                               false,
                               ValidationAttributes.First(x => !x.IsValid(Value)).FormatErrorMessage(Name));
            }
            catch
            {
                // ToDo нужно взять нормальный текст ошибки
                return new ValidationResult(false, GetErrorText(value.GetType()));
            }
        }

        protected virtual bool Validate() => ValidationAttributes.All(x => x.IsValid(Value));

        private string GetErrorText(MemberInfo type) => type.GetCustomAttribute<RangeAttribute>()?.FormatErrorMessage(Name) ?? "Add RangeAttribute to related property";
    }
}
