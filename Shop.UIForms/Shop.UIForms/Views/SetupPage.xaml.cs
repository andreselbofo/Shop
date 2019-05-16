using Shop.UIForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace Shop.UIForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage
    {
        string[] citas = { "Medico General : 15/02/2019 5:20 pm", "Odontologia : 19/06/2019 10:15 am", "Ortopedista : 20/07/2019 12:20 pm" };
       
        public SetupPage()
        {
            InitializeComponent();
            Inicializar();
            BindingContext = new SelectedDateViewModel();
            EspecialidadPicker.Items.Add("Medico General");
            EspecialidadPicker.Items.Add("Odontologia");
            EspecialidadPicker.Items.Add("Ortopedista");
          
        }

        private void Inicializar()
        {
            bindableradiogroupCitas.ItemsSource = citas;

            bindableradiogroupCitas.CheckedChanged += BindableradiogroupPaises_CheckedChanged;
        }
        private void Buscarbtn(object sender,EventArgs e)
        {
            
        }
        private void BindableradiogroupPaises_CheckedChanged(object sender, int e)
        {
            var radio = sender as CustomRadioButton;

            if(radio == null || radio.Id == -1)
            {
                return;
            }
           
        }
        private async void InicioBtn(object sender, EventArgs e)
        {
            await DisplayAlert("Confirmar Cita", "Es Correcto", "Guardar", "Cancelar");
        }

        private void EspecialidadPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
           var name = EspecialidadPicker.Items[EspecialidadPicker.SelectedIndex];
            DisplayAlert(name, "Listo", "OK");
        }
    }
}