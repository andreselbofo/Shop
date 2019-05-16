using Rg.Plugins.Popup.Services;
using Shop.UIForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shop.UIForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {

        public ProductsPage()
        {
            InitializeComponent();
        }
        private async void AgendarBtn(object sender, EventArgs e)
        {
            await App.Navigator.PushAsync(new SetupPage());
        }
        private async void ConsultarBtn(object sender, EventArgs e)
        {
            await App.Navigator.PushAsync(new AboutPage()); 
        }

    }
}