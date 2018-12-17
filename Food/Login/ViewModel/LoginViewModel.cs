using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Food.Client.Essentials.RelayCommand;

namespace Food.Login.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Visibility _loginVisibility;
        private Visibility _mainControlVisibility;

        public string UserName { get; set; }
        public ICommand  RegisterCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public Visibility LoginWindowVisibility
        {
            get { return _loginVisibility; }
            set { _loginVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoginWindowVisibility"));
            }
        }
        public Visibility MainControlVisibility
        {
            get { return _mainControlVisibility; }
            set { _mainControlVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MainControlVisibility"));
            }
        }

        public LoginViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
            SignUpCommand = new RelayCommand<object>(SignUp);
            MainControlVisibility = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SignUp(object obj)
        {
            LoginWindowVisibility = Visibility.Collapsed;
            MainControlVisibility = Visibility.Visible;
        }

        private void Register()
        {
        }
    }
}
