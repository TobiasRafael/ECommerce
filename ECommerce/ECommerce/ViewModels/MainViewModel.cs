using ECommerce.Models;
using ECommerce.Services;
using System;
using System.Collections.ObjectModel;

namespace ECommerce.ViewModels
{
    public class MainViewModel
    {
        #region Attributes
        private DataService _dataService;

        #endregion


        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public LoginViewModel NewLogin { get; set; }

        public UserViewModel UserLoged { get; set; }
        #endregion


        #region Constructors
        public MainViewModel()
        {
            // Singleton
            _instance = this;
            //Observable collections
            Menu = new ObservableCollection<MenuItemViewModel>();
            //Create Views
            NewLogin = new LoginViewModel();
            UserLoged = new UserViewModel();
            //Instance services
            _dataService = new DataService();
            //Load data
            LoadMenu();

        }

        #endregion

        #region Singleton
        private static MainViewModel _instance;

        public static MainViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MainViewModel();
            }
            return _instance;
        }
        #endregion


        #region Methods

        public void LoadUser(User user)
        {

            UserLoged.FullName = user.FullName;
            UserLoged.Photo = user.PhotoFullPath;

        }
        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                Icon = "product.png",
                PageName = "ProductsPage",
                Title = "Products",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "user.png",
                PageName = "CustomersPage",
                Title = "Customers",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "order.png",
                PageName = "OrdersPage",
                Title = "Orders",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "delivery.png",
                PageName = "DeliveriesPage",
                Title = "Deliveries",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "sync.png",
                PageName = "SyncPage",
                Title = "Sync",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "setup.png",
                PageName = "SetupPage",
                Title = "Setup",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "logout.png",
                PageName = "LogoutPage",
                Title = "Logout",
            });




        }
        #endregion

    }
}
