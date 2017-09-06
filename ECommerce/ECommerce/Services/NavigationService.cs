using ECommerce.Pages;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class NavigationService
    {

        public async Task Navigate (string pageName)
        {
            App.Master.IsPresented = false;

             switch(pageName)
            {
                case "CustomersPage":
                    await App.Navigator.PushAsync(new CustomersPage());
                    break;
                case "DeliveriesPage":
                    await App.Navigator.PushAsync(new DeliveriesPage());
                    break;
                case "OrdersPage":
                    await App.Navigator.PushAsync(new OrdersPage());
                    break;
                case "ProductsPage":
                    await App.Navigator.PushAsync(new ProductsPage());
                    break;
                case "SetupPage":
                    await App.Navigator.PushAsync(new SetupPage());
                    break;
                case "SyncPage":
                    await App.Navigator.PushAsync(new SyncsPage());
                    break;
                case "UserPage":
                    await App.Navigator.PushAsync(new UserPage());
                    break;
            }
        }
    }
}
