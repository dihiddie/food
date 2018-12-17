using System;
using System.Security;
using System.Windows.Input;
using ZAPC.Client.Controllers.CryptoProController;
using ZAPC.Client.Essentials;
using ZAPC.Client.Essentials.Commands;
using ZAPC.Core.Envelopes;
using ZAPC.Core.Logging;
using ZAPC.CspClient.CryptoPro;

namespace ZAPC.Client.ViewModels.CryptoProInitialization
{
    public class CryptoProInitializationViewModel : ViewModelBase
    {
        private const string WrongContainerInitialization = "Не удалось инициализировать контейнер.";

        private readonly ICryptoProController cryptoProController;

        private string containerName;

        private string errorMessage;

        private int tryingCount = 3;

        public CryptoProInitializationViewModel(ICryptoProController cryptoProController)
        {
            this.cryptoProController = cryptoProController;
            InitializeCommands();
        }

        public string ContainerName
        {
            get => containerName;
            set
            {
                containerName = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public SecureString Password { get; set; }

        public ICommand LoginCommand { get; set; }

        public ICommand GetContainerNameCommand { get; set; }

        private static bool ObjectIsIPasswordStorageInstance(object sender, out IPasswordStorage passwordStorage)
        {
            passwordStorage = null;
            if (sender is IPasswordStorage storage)
            {
                passwordStorage = storage;
                return true;
            }

            Log.Error("Невозможно преобразовать 'sender' к IPasswordStorage");
            return false;
        }

        private void InitializeCommands()
        {
            LoginCommand = new RelayCommand<object>(Login);
            GetContainerNameCommand = new RelayCommand<object>(GetContainerName);
        }

        private void GetContainerName(object sender)
        {
            try
            {
                ContainerName = CryptoProCspSigner.LetUserChooseContainer();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, WrongContainerInitialization);
                cryptoProController.InitializationFailed(sender);
            }
        }

        private void Login(object sender)
        {
            if (!ObjectIsIPasswordStorageInstance(sender, out IPasswordStorage passwordStorage)) return;
            try
            {
                CryptoPro.Signer = new CryptoProCspSigner<SimpleEnvelope>(
                    ContainerName,
                    passwordStorage.Password);
            }
            catch (Exception ex)
            {
                tryingCount--;
                ErrorMessage = $"Неверный PIN-код. Осталось попыток: {tryingCount}";
                passwordStorage.ClearPassword();

                if (tryingCount == 0)
                {
                    Log.Fatal(ex, WrongContainerInitialization);
                    cryptoProController.InitializationFailed(sender);
                }
            }

            cryptoProController.SuccessInitialization(sender);
        }
    }
}
