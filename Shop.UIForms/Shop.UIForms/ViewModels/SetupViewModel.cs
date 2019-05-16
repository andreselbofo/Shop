using GalaSoft.MvvmLight.Command;
using Shop.UIForms.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shop.UIForms.ViewModels
{
    public class SetupViewModel : BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;

        public bool IsRunning
        {
            get => this.isRunning;
            set => this.SetValue(ref this.isRunning, value);
        }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetValue(ref this.isEnabled, value);
        }
        public ICommand InicioCommand => new RelayCommand(this.Inicio);

        public SetupViewModel()
        {
            this.IsEnabled = true;
        }

        private async void Inicio()
        {
            this.IsEnabled = true;
            await App.Navigator.PushAsync(new ProductsPage());
        }
    }
}
