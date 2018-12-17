namespace ZAPC.Client.Essentials.MarkupExtentions
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Markup;

    public class Description : MarkupExtension
    {
        public Type Type { get; set; }

        public string PropertyName { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Type == null) throw new ArgumentNullException(nameof(Type));

            MemberInfo attributesSource;
            if (string.IsNullOrWhiteSpace(PropertyName)) attributesSource = Type;
            else attributesSource = Type.GetProperty(PropertyName);

            var description = attributesSource?.GetCustomAttributes<DescriptionAttribute>().SingleOrDefault()
                       ?.Description;

            if (string.IsNullOrWhiteSpace(description)) return description;

            var required = attributesSource?.GetCustomAttributes<RequiredAttribute>().Any();

            if (required == true) description += " *";

            return description;
        }
    }
}
