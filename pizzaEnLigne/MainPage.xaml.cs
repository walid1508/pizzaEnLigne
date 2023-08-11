using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pizzaEnLigne.Model;
using Xamarin.Forms;

namespace pizzaEnLigne
{
    public partial class MainPage : ContentPage
    {
        List<Pizza> pizzas;
        public MainPage()
        {
            InitializeComponent();

            pizzas = new List<Pizza>();
            pizzas.Add(new Pizza { _nom = "Vegetarienne", _prix = 7, _ingredients = new string[] { "tomates", "poivrons", "onions" }, _urlImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1-5LuPvnYqwDHqQSS9GADxHcxdTEpCXXuew&usqp=CAU" });
            pizzas.Add(new Pizza { _nom = "Montagna", _prix = 11, _ingredients = new string[] { "tomates", "poivrons", "onions" }, _urlImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSfEW1j6yrsJZ_sprBiE4cPslhc-U5_jMwuQ&usqp=CAU" });
            pizzas.Add(new Pizza { _nom = "carnivore", _prix = 17, _ingredients = new string[] { "lait", "crème", "sucre", "mayonaise", "tomates", "poivrons", "onions", "poulet", "boeuf", "fromage", "saucisse" }, _urlImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSiIF6fjmabTGBTI7DRLfICUTEnWCdnY1ybWA&usqp=CAU" });


            listView.ItemsSource = pizzas;
        }
    }
}

