using System.Collections.ObjectModel;

namespace ECommerce.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        #endregion


        #region Constructors
        public MainViewModel()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            LoadMenu();
        }

        #endregion

        #region Methods
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
                PageName = "LogOut",
                Title = "Logout",
            });




        }
        #endregion

    }
}
