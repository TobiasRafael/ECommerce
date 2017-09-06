using ECommerce.Services;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Windows.Input;
using System;

namespace ECommerce.ViewModels
{
    public class MenuItemViewModel
    {

        #region Attributes
        private NavigationService _navigationService;
        #endregion

        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Constructors
        public MenuItemViewModel ()
        {
            _navigationService = new NavigationService();
        }

        #endregion


        #region Commands
        public ICommand NavigateCommand { get { return new RelayCommand(Navigate); } }

        private async void Navigate()
        {
            await _navigationService.Navigate(PageName);
        }


        #endregion

    }


}
