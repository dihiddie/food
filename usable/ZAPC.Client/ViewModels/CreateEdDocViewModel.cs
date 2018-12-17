using System;

using Icl.Mvvm.Async;

namespace ZAPC.Client.ViewModels
{
    using System.Threading;
    using System.Threading.Tasks;

    using ZAPC.Client.Essentials;
    using ZAPC.Client.ViewModels.ED202;
    using ZAPC.Client.ViewModels.ED203;
    using ZAPC.Client.ViewModels.ED204;
    using ZAPC.Client.ViewModels.ED210;
    using ZAPC.Client.ViewModels.ED301;
    using ZAPC.Client.ViewModels.ED421;
    using ZAPC.Client.ViewModels.ED499;
    using ZAPC.Client.Views.ED202;
    using ZAPC.Client.Views.ED203;
    using ZAPC.Client.Views.ED204;
    using ZAPC.Client.Views.ED210;
    using ZAPC.Client.Views.ED301;
    using ZAPC.Client.Views.ED421;
    using ZAPC.Client.Views.ED499;
    using ZAPC.Documents.Ed202;
    using ZAPC.Documents.Ed203;
    using ZAPC.Documents.Ed204;
    using ZAPC.Documents.Ed210;
    using ZAPC.Documents.Ed301;
    using ZAPC.Documents.Ed421;
    using ZAPC.Documents.Ed499;
    using ZAPC.Documents.Ed999;

    public class CreateEdDocViewModel
    {
        public CreateEdDocViewModel()
        {
            CreateEd202();
            CreateEd203();
            CreateEd204();
            CreateEd210();
            CreateEd301();
            CreateEd421();
            CreateEd499();
            CreateEd999();
        }

        public event EventHandler<string> BusyContentChanged;

        public ICancellableAsyncCommand CreateEd202CommandAsync { get; set; }

        public ICancellableAsyncCommand CreateEd203CommandAsync { get; set; }

        public ICancellableAsyncCommand CreateEd204CommandAsync { get; set; }

        public ICancellableAsyncCommand CreateEd210CommandAsync { get; set; }

        public ICancellableAsyncCommand CreateEd301CommandAsync { get; set; }

        public ICancellableAsyncCommand CreateEd421CommandAsync { get; set; }

        public ICancellableAsyncCommand CreateEd499CommandAsync { get; set; }

        public ICancellableAsyncCommand CreateEd999CommandAsync { get; set; }

        public string CreateEd202CommandName { get; set; }

        public string CreateEd203CommandName { get; set; }

        public string CreateEd204CommandName { get; set; }

        public string CreateEd210CommandName { get; set; }

        public string CreateEd301CommandName { get; set; }

        public string CreateEd421CommandName { get; set; }

        public string CreateEd499CommandName { get; set; }

        public string CreateEd999CommandName { get; set; }

        private static async Task<string> GetDocumentName(string typeCode, CancellationToken token)
            => await Container.ServerObject.GetDocumentNameAsync(typeCode, token).ConfigureAwait(false);

        private void CreateEd202()
        {
            CreateEd202CommandName = "ED202";
            CreateEd202CommandAsync = new CancellableAsyncCommand(OpenEd202);
        }

        private void CreateEd999()
        {
            CreateEd999CommandName = "ED999";
            CreateEd999CommandAsync = new CancellableAsyncCommand(OpenEd999);
        }

        private async Task OpenEd202(CancellationToken token)
        {
            BusyContentChanged?.Invoke(this, Resources.SharedResources.GetDataFromServerCaption);
            var docName = await GetDocumentName(Ed202.TypeCode, token);
            BusyContentChanged?.Invoke(this, string.Empty);
            ED202View view = new ED202View(new Ed202ViewModel(new Ed202(), DocumentMode.New, docName));
            view.ShowDialog();
        }

        private async Task OpenEd999(CancellationToken token)
        {
            var docName = await GetDocumentName(Ed999.TypeCode, token);
            var model = new Ed999 { FileName = docName };
        }

        private void CreateEd203()
        {
            CreateEd203CommandName = "ED203";
            CreateEd203CommandAsync = new CancellableAsyncCommand(OpenEd203);
        }

        private async Task OpenEd203(CancellationToken token)
        {
            BusyContentChanged?.Invoke(this, Resources.SharedResources.GetDataFromServerCaption);
            var docName = await GetDocumentName(Ed203.TypeCode, token);
            BusyContentChanged?.Invoke(this, string.Empty);
            Ed203View view = new Ed203View(new Ed203ViewModel(new Ed203(), DocumentMode.New, docName));
            view.ShowDialog();
        }

        private void CreateEd204()
        {
            CreateEd204CommandName = "ED204";
            CreateEd204CommandAsync = new CancellableAsyncCommand(OpenEd204);
        }

        private async Task OpenEd204(CancellationToken token)
        {
            BusyContentChanged?.Invoke(this, Resources.SharedResources.GetDataFromServerCaption);
            var docName = await GetDocumentName(Ed204.TypeCode, token);
            BusyContentChanged?.Invoke(this, string.Empty);
            Ed204View view = new Ed204View(new Ed204ViewModel(new Ed204(), DocumentMode.New, docName));
            view.ShowDialog();
        }

        private void CreateEd210()
        {
            CreateEd210CommandName = "ED210";
            CreateEd210CommandAsync = new CancellableAsyncCommand(OpenEd210);
        }

        private async Task OpenEd210(CancellationToken token)
        {
            BusyContentChanged?.Invoke(this, Resources.SharedResources.GetDataFromServerCaption);
            var docName = await GetDocumentName(Ed210.TypeCode, token);
            BusyContentChanged?.Invoke(this, string.Empty);
            Ed210View view = new Ed210View(new Ed210ViewModel(new Ed210(), DocumentMode.New, docName));
            view.ShowDialog();
        }

        private void CreateEd301()
        {
            CreateEd301CommandName = "ED301";
            CreateEd301CommandAsync = new CancellableAsyncCommand(OpenEd301);
        }

        private async Task OpenEd301(CancellationToken token)
        {
            BusyContentChanged?.Invoke(this, Resources.SharedResources.GetDataFromServerCaption);
            var docName = await GetDocumentName(Ed301.TypeCode, token);
            BusyContentChanged?.Invoke(this, string.Empty);
            Ed301View view = new Ed301View(new Ed301ViewModel(new Ed301(), DocumentMode.New, docName));
            view.ShowDialog();
        }

        private void CreateEd421()
        {
            CreateEd421CommandName = "ED421";
            CreateEd421CommandAsync = new CancellableAsyncCommand(OpenEd421);
        }

        private async Task OpenEd421(CancellationToken token)
        {
            BusyContentChanged?.Invoke(this, Resources.SharedResources.GetDataFromServerCaption);
            var docName = await GetDocumentName(Ed301.TypeCode, token);
            BusyContentChanged?.Invoke(this, string.Empty);
            Ed421View view = new Ed421View(new Ed421ViewModel(new Ed421(), DocumentMode.New, docName));
            view.ShowDialog();
        }

        private void CreateEd499()
        {
            CreateEd499CommandName = "ED499";
            CreateEd499CommandAsync = new CancellableAsyncCommand(OpenEd499);
        }

        private async Task OpenEd499(CancellationToken token)
        {
            BusyContentChanged?.Invoke(this, Resources.SharedResources.GetDataFromServerCaption);
            var docName = await GetDocumentName(Ed499.TypeCode, token);
            BusyContentChanged?.Invoke(this, string.Empty);
            Ed499View view = new Ed499View(new Ed499ViewModel(new Ed499(), DocumentMode.New, docName));
            view.ShowDialog();
        }
    }
}
