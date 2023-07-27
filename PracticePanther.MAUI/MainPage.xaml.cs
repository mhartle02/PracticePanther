﻿using System.Linq;
using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void ClientsClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Clients");
        }

        private void EmployeeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Employee");
        }

        private void TimeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Times");
        }
    }
}