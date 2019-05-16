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
    public partial class AboutPage : ContentPage
    {
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.SettingsBindable(true)]
        public bool Checked { get; set; }
        public AboutPage()
        {
            InitializeComponent();   
        }

        private async void Eliminarbtn(object sender,EventArgs e)
        {
            if (MedicoGeneral != null)
            {
                await DisplayAlert("Quiere Eliminar Cita", "Esta Cita Sera Eliminada", "Si", "Cancelar");
                
            }
        }
        

    }
}