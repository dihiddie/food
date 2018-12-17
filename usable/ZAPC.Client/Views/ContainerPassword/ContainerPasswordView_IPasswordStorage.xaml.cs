namespace ZAPC.Client.Views.ContainerPassword
{
    using System.Security;
    using ZAPC.Client.Essentials;

    public partial class ContainerPasswordView : IPasswordStorage
    {
        public SecureString Password => ContainerPasswordBox.SecurePassword;

        public void ClearPassword() => ContainerPasswordBox.Clear();
    }
}
