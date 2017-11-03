using System;
using System.Collections.Generic;
using ICT13580010A2.Models;
using Xamarin.Forms;

namespace ICT13580010A2
{
    public partial class ProductNewPage : ContentPage
    {
        Product product;

        public ProductNewPage(Product product=null)
        {
            InitializeComponent();

            this.product = product;

            titleLabel.Text = product == null ? "New Product" : "Edit Product";

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            categoryPicker.Items.Add("Shirts");
            categoryPicker.Items.Add("Shorts");
            categoryPicker.Items.Add("Socks");

            if (product != null)
            {
                nameEntry.Text = product.Name;
                descriptionEditor.Text = product.Description;
                categoryPicker.SelectedItem = product.Category;
                pPriceEntry.Text = product.ProductPrice.ToString();
                sPriceEntry.Text = product.SellPrize.ToString();
                stockEntry.Text = product.Stock.ToString();
            }

        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("Confirm", "Do you want to save?", "Yes", "No");

            if (isOk)
            {
                if (product == null)
                {
                    product = new Product();

                    product.Name = nameEntry.Text;
                    product.Description = descriptionEditor.Text;
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.ProductPrice = decimal.Parse(pPriceEntry.Text);
                    product.SellPrize = decimal.Parse(sPriceEntry.Text);
                    product.Stock = int.Parse(stockEntry.Text);

                    var id = App.DbHelper.AddProduct(product);

                    await DisplayAlert("Product is saved", "The Product Id is #" + id, "Done");
                }

                else
                {
                    product.Name = nameEntry.Text;
                    product.Description = descriptionEditor.Text;
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.ProductPrice = decimal.Parse(pPriceEntry.Text);
                    product.SellPrize = decimal.Parse(sPriceEntry.Text);
                    product.Stock = int.Parse(stockEntry.Text);

                    var id = App.DbHelper.UpdateProduct(product);

                    await DisplayAlert("Product edit is completed", "The Product Id is #" + id, "Done");
                }




                await Navigation.PopModalAsync();
            }


        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
