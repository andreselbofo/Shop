﻿

namespace Shop.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Shop.Common.Models;
    using Shop.Common.Services;
    using Shop.UIForms.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        private readonly ApiService apiService;

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

        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.Email = "andresdesarrollo1997@gmail.com";
            this.Password = "123456";
            this.IsEnabled = true;
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa Tu Correo",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa Tu Contraseña",
                    "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var request = new TokenRequest
            {
                Password = this.Password,
                Username = this.Email
            };

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetTokenAsync(
                url,
                "/Account",
                "/CreateToken",
                request);

            this.IsRunning = false;
            this.IsEnabled = true;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email o contraseña incorrectos.", "Accept");
                return;
            }

            var token = (TokenResponse)response.Result;
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            mainViewModel.Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }

    }
}
