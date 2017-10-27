using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ICT13580010A2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            newButton.Clicked += NewButton_Clicked;
        }

        void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductNewPage());
        }
    }
}
