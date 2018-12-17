namespace ZAPC.Client.Essentials.Bindings
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Xaml;

    using JetBrains.Annotations;

    using ZAPC.Client.Essentials.ValidationRules;
    using ZAPC.Documents;

    public sealed class CustomBinding : BindingDecoratorBase
    {
        private BindingExpression bindingExpression;
        private BindData data;
        private string rootPath;

        [NotNull]
        private DependencyObject dependencyObject;
        [NotNull]
        private DependencyProperty dependencyProperty;

        // ReSharper disable once NotNullMemberIsNotInitialized
        public CustomBinding()
        {
            ValidationRules.Add(new ValidationFromAttributeRule());

            NotifyOnSourceUpdated = true;
            NotifyOnTargetUpdated = true;
            NotifyOnValidationError = true;
            ValidatesOnDataErrors = true;
            ValidatesOnExceptions = true;
            ValidatesOnNotifyDataErrors = true;

            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }

        [NotNull]
        public BindingExpression BindingExpression
        {
            get
            {
                if (bindingExpression == null)
                    bindingExpression = BindingOperations.GetBindingExpression(dependencyObject, dependencyProperty);
                return bindingExpression ?? throw new InvalidOperationException();
            }
        }

        [DefaultValue(null)]
        public string RootPath { get; set; }

        public override object ProvideValue(IServiceProvider provider)
        {
            data = new BindData(GetValue, GetErrors, ClearErrors);
            data.HasErrorChanged += HasErrorChanged;

            var context = GetDataContext(provider) ?? throw new ArgumentNullException();

            if (!TryGetTargetItems(provider, out dependencyObject, out dependencyProperty))
                throw new Exception("Fucking wired exception for others bindings to work");

            if (string.IsNullOrEmpty(RootPath))
            {
                var buf = Path.Path.Split(new[] { '.' }, 2);
                rootPath = buf[0];
                var relPath = buf[1];

                var model = context.GetType().GetProperty(rootPath)?.GetValue(context);

                if (model is IBindDataDictionary dictionary)
                {
                    if (!dictionary.BindData.ContainsKey(relPath))
                        dictionary.BindData.Add(relPath, data);

                    if (dictionary.IsValueSet.ContainsKey(relPath) && dictionary.IsValueSet[relPath])
                        Mode = BindingMode.TwoWay;
                    else
                        Mode = dependencyObject is ComboBox ? BindingMode.TwoWay : BindingMode.OneWayToSource;
                }
            }
            else
            {
                // RootPath not null only for arrays
                var buf = RootPath.Split(new[] { '.' }, 2);
                rootPath = buf[0];
                var list = (IList)GetPropValue(context, RootPath);

                var model = context.GetType().GetProperty(rootPath)?.GetValue(context);
                if (model is IBindDataDictionary dictionary)
                {
                    var relPath = $"{buf[1]}[{list.Count-1}].{Path.Path}";
                    data.RootRef = list[list.Count - 1];
                    dictionary.BindData.Add(relPath, data);

                    // ToDo Need to Test with predefined guarantiee list
                    if (dictionary.IsValueSet.ContainsKey(relPath))
                        Mode = dictionary.IsValueSet[relPath] ? BindingMode.TwoWay : BindingMode.OneWayToSource;
                    else
                    {
                        dictionary.IsValueSet.Add(relPath, false);
                        Mode = BindingMode.OneWayToSource;
                    }
                }
            }

            return base.ProvideValue(provider);
        }

        private static object GetPropValue([NotNull] object context, [NotNull] string path)
        {
            var buf = path.Split(new[] { '.' }, 2);

            var obj = context.GetType().GetProperty(buf[0])?.GetValue(context, null) ?? throw new ArgumentNullException();
            return buf.Length > 1 ? GetPropValue(obj, buf[1]) : obj;
        }

        [CanBeNull]
        private static object GetDataContext([NotNull] IServiceProvider provider)
        {
            var service = (IRootObjectProvider)provider.GetService(typeof(IRootObjectProvider));
            var result = (service?.RootObject as Window)?.DataContext;
            return result;
        }

        private void ClearErrors()
        {
            if (dependencyObject is FrameworkElement fe)
                fe.Tag = null;
            Validation.ClearInvalid(BindingExpression);
        }

        [NotNull]
        private ICollection<ValidationError> GetErrors()
        {
            var result = new List<ValidationError>();
            foreach (var vr in ValidationRules)
            {
                var validationResult = vr.Validate(GetValue(), CultureInfo.CurrentCulture, BindingExpression);
                if (!validationResult.IsValid)
                    result.Add(new ValidationError(vr, BindingExpression, validationResult.ErrorContent, null));
            }

            return result;
        }

        [CanBeNull]
        private string GetValue() => dependencyObject.GetValue(dependencyProperty)?.ToString();

        private void HasErrorChanged(object sender, [NotNull] ErrorChangedEventArgs e) => ShowError(e.ErrorText);

        private void ShowError(string errorText)
        {
            var validationRule = ValidationRules.FirstOrDefault(x => x is ValidationFromAttributeRule);

            // ReSharper disable once AssignNullToNotNullAttribute should not be null becouse [ValidationFromAttributeRule] added in costructor
            var validationError = new ValidationError(validationRule, BindingExpression) { ErrorContent = errorText };
            if (dependencyObject is FrameworkElement fe)
                fe.Tag = "error";

            Validation.MarkInvalid(BindingExpression, validationError);
        }
    }
}