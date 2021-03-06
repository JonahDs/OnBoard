﻿using Newtonsoft.Json;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.ViewModels
{
    public class FoodViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        public ObservableCollection<Product> ProductsOnSale { get; set; }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products { get { return this._products; } set { Set(ref _products, value); } }

        private ObservableCollection<Product> _filteredProducts;
        public ObservableCollection<Product> FilteredProducts { get { return this._filteredProducts; } set { Set(ref _filteredProducts, value); } }

        private ObservableCollection<Product> _selectedProducts;
        public ObservableCollection<Product> SelectedProducts { get { return this._selectedProducts; } set { Set(ref _selectedProducts, value); } }

        public RelayCommand AddProductToBasketCommand { get; set; }
        public RelayCommand DeleteProductFromBasketCommand { get; set; }
        public RelayCommand FilterProductsCommand { get; set; }


        /// <summary>
        /// Constructor that calls getProducts() method
        /// </summary>
        public FoodViewModel()
        {
            Products = new ObservableCollection<Product>();
            ProductsOnSale = new ObservableCollection<Product>();
            SelectedProducts = new ObservableCollection<Product>();
            FilteredProducts = Products;
            GetProducts();

            AddProductToBasketCommand = new RelayCommand(productid => AddProductToBasket((int)productid));
            DeleteProductFromBasketCommand = new RelayCommand(productid => DeleteProductFromBasket((int)productid));
            FilterProductsCommand = new RelayCommand(foodcategory => FilterProducts((string)foodcategory));
        }


        /// <summary>
        /// Calls the api for the products
        /// </summary>
        /// <returns></returns>
        private async void GetProducts()
        {
            Uri requestUri = new Uri("http://localhost:50236/api/product");

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {

                httpResponse = await client.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ObservableCollection<Product>>(httpResponseBody);
                data.ToList().ForEach(p =>
                {
                    if (p.Sale == 0)
                    {
                        Products.Add(p);
                    }
                    else
                    {
                        ProductsOnSale.Add(p);
                    }
                });
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
        }

        private void FilterProducts(string foodCategory)
        {
            switch (foodCategory)
            {
                case "All":
                    FilteredProducts = Products;
                    break;
                case "Dinner":
                    FilteredProducts = new ObservableCollection<Product>(Products.Where(p => p.ProductType.Equals("Dinner")));
                    break;
                case "Snacks":
                    FilteredProducts = new ObservableCollection<Product>(Products.Where(p => p.ProductType.Equals("Snacks")));
                    break;
                case "Drinks":
                    FilteredProducts = new ObservableCollection<Product>(Products.Where(p => p.ProductType.Equals("Drinks")));
                    break;
            }
        }

        private void AddProductToBasket(int productId)
        {
            var product = Products.ToList().FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                SelectedProducts.Add(product);
            }
            else
            {
                product = ProductsOnSale.ToList().FirstOrDefault(p => p.ProductId == productId);
                SelectedProducts.Add(product);
            }
        }

        private void DeleteProductFromBasket(int productId)
        {
            var prod = SelectedProducts.FirstOrDefault(p => p.ProductId == productId);
            if (prod != null)
            {
                SelectedProducts.Remove(prod);
            }
        }

        public void Refresh() {
            Products.Clear();
            ProductsOnSale.Clear();
            SelectedProducts.Clear();
            FilteredProducts = Products;
            GetProducts();
        }
    }
}
