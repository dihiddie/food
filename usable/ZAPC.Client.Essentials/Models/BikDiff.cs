namespace ZAPC.Client.Essentials.Models
{
    public class BikDiff
    {
        public string Vkey { get; set; }

        public string FieldName { get; set; }

        public object OldValue { get; set; }

        public object NewValue { get; set; }
    }
}
