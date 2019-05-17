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
        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                //reconfigure layout
            }
        }
        private async void AgendarBtn(object sender, EventArgs e)
        {
            await App.Navigator.PushAsync(new SetupPage());
        }
        private async void ConsultarBtn(object sender, EventArgs e)
        {
            await App.Navigator.PushAsync(new AboutPage()); 
        }
        private async void Infobtn(object sender, EventArgs e)
        {
            await App.Navigator.PushAsync(new InicioPage());
        }

    }
}