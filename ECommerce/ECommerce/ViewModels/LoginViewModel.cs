using ECommerce.Models;
using ECommerce.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECommerce.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private NavigationService _navigationService;

        private DialogService _dialogService;

        private ApiService _apiService;

        private DataService _dataService;

        

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public string User { get; set; }

        public string Password { get; set; }

        public bool IsRemembered { get; set; }

        public bool IsRunning { get; set; }

        public bool IsCmdVisible { get; set; }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            _navigationService = new NavigationService();
            _dialogService = new DialogService();
            _apiService = new ApiService();
            _dataService = new DataService();
            IsRemembered = true;
            IsCmdVisible = true;
        } 
        #endregion

        #region Commands
        public ICommand LoginCommand { get { return new RelayCommand(Login); } }
        private async void Login()
        {
            if (string.IsNullOrEmpty(User))
            {
                await _dialogService.ShowMessage("Error", "You must enter a valid username");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await _dialogService.ShowMessage("Error", "You must enter a password");
                return;
            }

            
            IsRunning = true;
            IsCmdVisible = false;

            var response = await _apiService.Login(User, Password);
            IsRunning = false;
            IsCmdVisible = true;

            if (!response.IsSuccess)
            {
                await _dialogService.ShowMessage("Error", response.Message);
                return;
            }

            var user = (User)response.Result;
            user.IsRemembered = IsRemembered;
            user.Password = Password;

            _dataService.InsertUser(user);
            _navigationService.SetMainPage(user);

            
        }
        #endregion
    }
}
