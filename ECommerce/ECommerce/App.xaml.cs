using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Pages;

using Xamarin.Forms;
using ECommerce.Services;
using ECommerce.Models;
using ECommerce.ViewModels;

namespace ECommerce
{
    public partial class App : Application
    {
        #region Attributes
        private DataService _dataService; 
        #endregion

        #region Properties
        public static NavigationPage Navigator { get; internal set; }
        public static MainPage Master { get; internal set; }
        public static User CurrentUser { get; internal set; }

        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();

            _dataService = new DataService();
            var user = _dataService.GetUser();

            if (user != null && user.IsRemembered)
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.LoadUser(user);
                App.CurrentUser = user;
                MainPage = new MainPage();

            }
            else
            {
                MainPage = new LoginPage();
            }

            
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
