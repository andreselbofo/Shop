using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Shop.UIForms.ViewModels
{
    public class SelectedDateViewModel
    {
        private readonly string FullDateFormat = "dddd, MMMM d, yyyy";

        private DateTime selectedDate;

        public event PropertyChangedEventHandler PropertyChanged;

        public SelectedDateViewModel()
        {
            Debug.WriteLine("Entering SelectedDateViewModel.SelectedDateViewModel() - Constructor");

            SelectedDate = DateTime.Now;

            Debug.WriteLine("Leaving SelectedDateViewModel.SelectedDateViewModel() - Constructor");
        }

        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }

            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine("Inside SelectedDateViewModel.OnPropertyChanged()");

            Debug.WriteLine($"SelectedDate = {selectedDate.ToString(FullDateFormat)}");

            var trace =
            $"PropertyChanged Is Null: {(PropertyChanged == null ? "Yes" : "No")}";
            Debug.WriteLine(trace);

            var propertyChangedCallback = PropertyChanged;
            propertyChangedCallback?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
