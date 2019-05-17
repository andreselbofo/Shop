using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Shop.UIForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
          // MapView.MoveToRegion(
          // MapSpan.FromCenterAndRadius(
          //new Xamarin.Forms.Maps.Position(37, -122), Distance.FromMiles(1)));
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
        //private void Street_OnClicked(object sender, EventArgs e)
        //{
        //   MapView.MapType = MapType.Street;
        //}


        //private void Hybrid_OnClicked(object sender, EventArgs e)
        //{
        //    MapView.MapType = MapType.Hybrid;
        //}

        //private void Satellite_OnClicked(object sender, EventArgs e)
        //{
        //    MapView.MapType = MapType.Satellite;
        //}
    }
}