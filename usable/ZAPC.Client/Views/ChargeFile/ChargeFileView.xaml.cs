namespace ZAPC.Client.Views.ChargeFile
{
    using ZAPC.Client.ViewModels;
    using ZAPC.Documents.Ed101;

    public partial class ChargeFileView
    {
        public ChargeFileView()
        {
            InitializeComponent();
        }

        public ChargeFileView(DocumentViewModel<Ed101> viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
