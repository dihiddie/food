namespace ZAPC.Client.ViewModels.ChargeFile
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Documents.Ed101;

    public class CheckChargeFileViewModel : DocumentViewModel<Ed101>
    {
        public CheckChargeFileViewModel([NotNull] Ed101 model, DocumentMode mode, [CanBeNull] string fileName = null)
            : base(model, mode, fileName)
        {
            ModelForCheck = Ed101.Parse(Model.XmlContent);
            Model = new Ed101
                        {
                            EdDate = DateTime.Now,
                            Encoding = Encoding.UTF8,
                            DepartmentalInfo = { DocDate = DateTime.Now }
                        };
        }

        public Ed101 ModelForCheck { get; set; }

        protected override async Task SendDocumentToServerAsync(CancellationToken token)
        {
            if (!Model.IsValid()) return;

            if (!Model.DictionaryEquals(ModelForCheck, out string[] notEqualsProperties))
            {
                if (notEqualsProperties == null) return;

                foreach (var property in notEqualsProperties)
                    Model.BindData[property]?.OnError(
                        $"Значение в проверочном документе: {ModelForCheck.GetNestedPropertyValue(property) ?? "<нет значения>"}");

                return;
            }

            await Container.ServerObject.SendChargeFileAsync(Model.FileName, Model.Encoding.GetBytes(Model.XmlContent), token).ConfigureAwait(false);
        }
    }
}
