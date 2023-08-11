using System;
using pizzaEnLigne.extensions;

namespace pizzaEnLigne.Model
{
    public class Pizza
    {
        public string _nom { get; set; }
        public int _prix { get; set; }
        public string[] _ingredients { get; set; }
        public string _urlImage { get; set; }

        public string PrixCAD { get { return _prix + " $"; } }
        public string IngredientsString { get { return String.Join(",", _ingredients); } }
        public string Titre { get { return _nom.PremiereLettreMaj(); } }

        public Pizza()
        {

        }
    }
}

