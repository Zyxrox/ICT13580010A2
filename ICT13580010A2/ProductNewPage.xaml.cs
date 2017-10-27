using System;
using System.Collections.Generic;
using ICT13580010A2.Models;
using Xamarin.Forms;

namespace ICT13580010A2
{
    public partial class ProductNewPage : ContentPage
    {
        public ProductNewPage()
        {
            InitializeComponent();

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            categoryPicker.Items.Add("Shirts");
            categoryPicker.Items.Add("Shorts");
            categoryPicker.Items.Add("Socks");

        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("Confirm", "Do you want to save?", "Yes", "No");

            if (isOk)
            {
                var product = new Product();
                product.Name = nameEntry.Text;
                product.Description = descriptionEditor.Text;
                product.Category = categoryPicker.SelectedItem.ToString();
                product.ProductPrice = decimal.Parse(pPriceEntry.Text);
                product.SellPrize = decimal.Parse(sPriceEntry.Text);
                product.Stock = int.Parse(stockEntry.Text);
                var id = App.DbHelper.AddProduct(product);
                await DisplayAlert("Product is saved", "The Product Id is #" + id, "Done");

            }


        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
