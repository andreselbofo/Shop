using GalaSoft.MvvmLight.Command;
using Shop.Common.Models;
using Shop.UIForms.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Shop.UIForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance;

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public TokenResponse Token { get; set; }
        
        public string UserEmail { get; set; }
        
        public string UserPassword { get; set; }

        public LoginViewModel Login { get; set; }

        public RegisterViewModel Register { get; set; }

        public  ProductsViewModel Products { get; set; }

        public AddProductViewModel AddProduct { get; set; }

        public EditProductViewModel EditProduct { get; set; }

        public RememberPasswordViewModel RememberPassword { get; set; }

        public InicioViewModel Inicio { get; set; }

        public SetupViewModel Setup { get; set; }

        public ICommand AddProductCommand { get { return new RelayCommand(this.GoAddProduct); } }

        private async void GoAddProduct()
        {
            this.AddProduct = new AddProductViewModel();
            //await App.Navigator.PushAsync(new AddProductPage());
        }

        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }

        private void LoadMenus()
        {
            var menus = new List<Menu>
        {
        new Menu
        {
            Icon = "ic_action_assignment",
            PageName = "AboutPage",
            Title = "Consultar Cita"
        },

        new Menu
        {
            Icon = "ic_action_search",
            PageName = "SetupPage",
            Title = "Agendar Cita"
        },

        new Menu
        {
            Icon = "ic_exit_to_app",
            PageName = "LoginPage",
            Title = "Close session"
        }
    };

            this.Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m => new MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }


        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
