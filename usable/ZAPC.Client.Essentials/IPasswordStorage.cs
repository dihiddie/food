namespace ZAPC.Client.Essentials
{
    using System.Security;

    public interface IPasswordStorage
    {
        SecureString Password { get; }

        void ClearPassword();
    }
}
