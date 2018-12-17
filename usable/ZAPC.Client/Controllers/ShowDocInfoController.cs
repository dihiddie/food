namespace ZAPC.Client.Controllers
{
    using Documents;
    using Documents.Ed202;
    using Documents.Ed203;
    using Documents.Ed204;
    using Documents.Ed210;
    using Documents.Ed301;
    using Documents.Ed421;
    using Documents.Ed499;

    using Essentials;

    using ShowFileInfo;

    using ViewModels.ED202;
    using ViewModels.ED203;
    using ViewModels.ED204;
    using ViewModels.ED210;
    using ViewModels.ED301;
    using ViewModels.ED421;
    using ViewModels.ED499;

    using Views.ED202;
    using Views.ED203;
    using Views.ED204;
    using Views.ED210;
    using Views.ED301;
    using Views.ED421;
    using Views.ED499;

    public class ShowDocInfoController : IShowFileInfoController
    {
        public void ShowFileInfo(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public void ShowFileInfo(object obj)
        {
            if (!(obj is IDocumentWithCreationDateTime docObg)) return;
            if (docObg.FileName.Contains("202"))
            {
                ED202View view = new ED202View(new Ed202ViewModel((Ed202)obj, DocumentMode.Readonly));
                view.ShowDialog();
            }
            else if (docObg.FileName.Contains("203"))
            {
                Ed203View view = new Ed203View(new Ed203ViewModel((Ed203)obj, DocumentMode.Readonly));
                view.ShowDialog();
            }
            else if (docObg.FileName.Contains("204"))
            {
                Ed204View view = new Ed204View(new Ed204ViewModel((Ed204)obj, DocumentMode.Readonly));
                view.ShowDialog();
            }
            else if (docObg.FileName.Contains("210"))
            {
                Ed210View view = new Ed210View(new Ed210ViewModel((Ed210)obj, DocumentMode.Readonly));
                view.ShowDialog();
            }
            else if (docObg.FileName.Contains("301"))
            {
                Ed301View view = new Ed301View(new Ed301ViewModel((Ed301)obj, DocumentMode.Readonly));
                view.ShowDialog();
            }
            else if (docObg.FileName.Contains("421"))
            {
                Ed421View view = new Ed421View(new Ed421ViewModel((Ed421)obj, DocumentMode.Readonly));
                view.ShowDialog();
            }
            else if (docObg.FileName.Contains("499"))
            {
                Ed499View view = new Ed499View(new Ed499ViewModel((Ed499)obj, DocumentMode.Readonly));
                view.ShowDialog();
            }
        }
    }
}
