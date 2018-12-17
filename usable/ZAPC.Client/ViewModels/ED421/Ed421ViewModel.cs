namespace ZAPC.Client.ViewModels.ED421
{
    using System.Linq;
    using System.Windows.Input;

    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Client.Essentials.Commands;
    using ZAPC.Documents.Ed421;

    public sealed class Ed421ViewModel : DocumentViewModel<Ed421>
    {
        public Ed421ViewModel([NotNull] Ed421 model, DocumentMode mode, [CanBeNull] string fileName = null) : base(model, mode, fileName)
        {
            InintCommands();
        }

        public ICommand AddNewGuaranteeCommand { get; set; }

        public ICommand RemoveGuaranteeCommand { get; set; }

        private void InintCommands()
        {
            AddNewGuaranteeCommand = new RelayCommand(AddNewGuarantee);
            RemoveGuaranteeCommand = new RelayCommand<object>(RemoveGuarantee);
        }

        private void AddNewGuarantee()
        {
            Model.CreditOpTerms.Guarantee.Add(new Guarantee());
        }

        private void RemoveGuarantee(object obj)
        {
            if (!(obj is Guarantee guarantee)) return;

            var toRemove = Model.BindData.Where(x => x.Value.RootRef?.Equals(guarantee) == true).Select(k => k.Key)
                .ToList();
            foreach (var key in toRemove)
                Model.BindData.Remove(key);

            Model.CreditOpTerms.Guarantee.Remove(guarantee);
            for (var i = 0; i < Model.CreditOpTerms.Guarantee.Count; i++)
            {
                var item = Model.CreditOpTerms.Guarantee[i];
                var related = Model.BindData.Where(x => x.Value.RootRef?.Equals(item) == true).Select(k => k.Key).ToList();
                foreach (var key in related)
                {
                    var data = Model.BindData[key];
                    Model.BindData.Remove(key);

                    var buf = key.Split('.');
                    var propName = buf[buf.Length - 1];
                    Model.BindData.Add($"CreditOpTerms.Guarantee[{i}].{propName}", data);
                }
            }
        }
    }
}
