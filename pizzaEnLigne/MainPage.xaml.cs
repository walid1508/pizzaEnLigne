using System.Collections.Generic;
using pizzaEnLigne.Model;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;
using System;

namespace pizzaEnLigne
{
    public partial class MainPage : ContentPage
    {
        //List<Pizza> pizzas;
        public MainPage()
        {
            InitializeComponent();


            listView.RefreshCommand = new Command(() =>
            {
                downloadData((pizzas) =>
                {
                    listView.ItemsSource = pizzas;
                    listView.IsRefreshing = false;
                });

            });
            listView.IsVisible = false;
            waitLayout.IsVisible = true;
            //string pizzaJson = "";
            //appel à downloadData
            downloadData((pizzas) =>
            {
                listView.ItemsSource = pizzas;
                waitLayout.IsVisible = false;
                listView.IsVisible = true;
            });

            //pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzaJson);

            #region Liste de pizzas en texte dure
            //pizzas.Add(new Pizza { _nom = "Vegetarienne", _prix = 7, _ingredients = new string[] { "tomates", "poivrons", "onions" }, _urlImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1-5LuPvnYqwDHqQSS9GADxHcxdTEpCXXuew&usqp=CAU" });
            //pizzas.Add(new Pizza { _nom = "Montagna", _prix = 11, _ingredients = new string[] { "tomates", "poivrons", "onions" }, _urlImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSfEW1j6yrsJZ_sprBiE4cPslhc-U5_jMwuQ&usqp=CAU" });
            //pizzas.Add(new Pizza { _nom = "carnivore", _prix = 17, _ingredients = new string[] { "lait", "crème", "sucre", "mayonaise", "tomates", "poivrons", "onions", "poulet", "boeuf", "fromage", "saucisse" }, _urlImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSiIF6fjmabTGBTI7DRLfICUTEnWCdnY1ybWA&usqp=CAU" });
            #endregion


            //listView.ItemsSource = pizzas;
        }

        private void WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void downloadData(Action<List<Pizza>> action)
        {
            using (var webClient = new WebClient())
            {
                const string URL = "https://drive.google.com/uc?export=download&id=1zd9yARi3E923ylQ5VRGSb4SETR8hROU1";

                //pizzaJson = webClient.DownloadString(URL);
                webClient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                {
                    Console.WriteLine("Données téléchargées : " + e.Result);
                    try
                    {
                        string pizzaJson = e.Result;
                        List<Pizza> pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzaJson);

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            action.Invoke(pizzas);
                        });
                    }
                    catch (Exception ex)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Erreur ", "est : ", ex.Message, "ok");
                            action.Invoke(null);
                        });
                    }
                };

                webClient.DownloadStringAsync(new Uri(URL));


            }
        }
    }
}

