namespace ZAPC.Client.ViewModels.ED202
{
    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Documents.Ed202;

    public sealed class Ed202ViewModel : DocumentViewModel<Ed202>
    {
        /*
        var allValuesXml = @"<?xml version=""1.0"" encoding=""WINDOWS-1251""?><ED202 xmlns=""urn:cbr-ru:ed:v2.0"" EDNo=""8"" EDDate=""2003-04-14"" EDAuthor=""4525545000"" EDReceiver=""4525000000"" EDInquiryCode=""RCPY""><EDRefID EDNo=""7"" EDDate=""2003-04-14"" EDAuthor=""4525545000"" /></ED202>";
        var notAllXml = @"<?xml version=""1.0"" encoding=""WINDOWS-1251""?><ED202 xmlns=""urn:cbr-ru:ed:v2.0"" EDNo=""8"" EDDate=""2003-04-14"" EDAuthor=""4525545000"" EDReceiver=""4525000000"" EDInquiryCode=""RCPY""><EDRefID/></ED202>";
        */

        public Ed202ViewModel([NotNull] Ed202 model, DocumentMode mode, [CanBeNull] string fileName = null) : base(model, mode, fileName)
        {
        }
    }
}