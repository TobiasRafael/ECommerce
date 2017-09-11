using ECommerce.Models;
using ECommerce.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.ComponentModel;
using System.Linq;

namespace ECommerce.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private DataService _dataService;
        private ApiService _apiService;
        private NetService _netService;
        private string _productsfilter;
        private string _customerfilter;
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public ObservableCollection<ProductItemViewModel> Products { get; set; }

        public ObservableCollection<CustomerItemViewModel> Customers { get; set; }

        public LoginViewModel NewLogin { get; set; }

        public UserViewModel UserLoged { get; set; }

        public string ProductsFilter
        {
            set
            {

                if (_productsfilter != value)
                {
                    _productsfilter = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductsFilter"));

                    if (string.IsNullOrEmpty(_productsfilter))
                    {
                        LoadLocalProducts();
                    }
                }
            }
            get
            {
                return _productsfilter;
            }
        }

        public string CustomersFilter
        {
            set
            {

                if (_customerfilter != value)
                {
                    _customerfilter = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("CustomersFilter"));

                    if (string.IsNullOrEmpty(_customerfilter))
                    {
                        LoadLocalCustomers();
                    }
                }
            }
            get
            {
                return _customerfilter;
            }
        }

        


        #endregion

        #region Constructors
        public MainViewModel()
        {
            // Singleton
            _instance = this;

            //Observable collections
            Menu = new ObservableCollection<MenuItemViewModel>();
            Products = new ObservableCollection<ProductItemViewModel>();
            Customers = new ObservableCollection<CustomerItemViewModel>();

            //Create Views
            NewLogin = new LoginViewModel();
            UserLoged = new UserViewModel();

            //Instance services
            _dataService = new DataService();
            _apiService = new ApiService();
            _netService = new NetService();

            //Load data
            LoadMenu();
            LoadProducts();
            LoadCustomers();

        }

       


        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
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

        private void LoadLocalCustomers()
        {
            var customers = _dataService.Get<Customer>(true);
            ReloadCustomers(customers);
        }


        private async void LoadCustomers()
        {
            var customers = new List<Customer>();

            if (_netService.IsConnected())
            {
                customers = await _apiService.Get<Customer>("Customers");
                _dataService.Save(customers);
            }
            else
            {
                customers = _dataService.Get<Customer>(true);
            }
            ReloadCustomers(customers);
        }

        private void ReloadCustomers(List<Customer> customers)
        {
            Customers.Clear();
            foreach (var customer in customers.OrderBy(c => c.FirstName).ThenBy(c => c.LastName))
            {
                Customers.Add(new CustomerItemViewModel
                {
                   Address = customer.Address,
                   City = customer.City,
                   CityId = customer.CityId,
                   CompanyCustomers = customer.CompanyCustomers,
                   CustomerId = customer.CustomerId,
                   Department = customer.Department,
                   DepartmentId = customer.DepartmentId,
                   FirstName = customer.FirstName,
                   IsUpdated = customer.IsUpdated,
                   LastName = customer.LastName,
                   Latitude = customer.Latitude,
                   Longitude = customer.Longitude,
                   Orders = customer.Orders,
                   Phone = customer.Phone,
                   Photo = customer.Photo,
                   Sales = customer.Sales,
                   UserName = customer.UserName,
                });
            }
        }

        private void LoadLocalProducts()
        {
            var products = _dataService.Get<Product>(true);
            ReloadProducts(products);
        }


        private async void LoadProducts()
        {
            var products = new List<Product>();

            if (_netService.IsConnected())
            {
                products = await _apiService.Get<Product>("Products");
                _dataService.Save(products);
            }
            else
            {
                products = _dataService.Get<Product>(true);
            }
            ReloadProducts(products);


        }

        private void ReloadProducts(List<Product> products)
        {
            Products.Clear();
            foreach (var product in products.OrderBy(p => p.Description))
            {
                Products.Add(new ProductItemViewModel
                {
                    BarCode = product.BarCode,
                    Category = product.Category,
                    CategoryId = product.CategoryId,
                    Company = product.Company,
                    CompanyId = product.CompanyId,
                    Description = product.Description,
                    Image = product.Image,
                    Inventories = product.Inventories,
                    Price = product.Price,
                    ProductId = product.ProductId,
                    Remarks = product.Remarks,
                    Stock = product.Stock,
                    Tax = product.Tax,
                    TaxId = product.TaxId,
                });
            }
        }

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

        #region Commands

        public ICommand SearchProductCommand { get { return new RelayCommand(SearchProduct); } }

        private void SearchProduct()
        {

            var products = _dataService.GetProducts(ProductsFilter);
            ReloadProducts(products);
                     
        }

        public ICommand SearchCustomerCommand { get { return new RelayCommand(SearchCustomer); } }

        private void SearchCustomer()
        {
            var customers = _dataService.GetCustomers(CustomersFilter);
            ReloadCustomers(customers);
        }


        #endregion

    }
}
