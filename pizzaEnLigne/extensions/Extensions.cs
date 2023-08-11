using System;
namespace pizzaEnLigne.extensions
{
    public static class StringExtensions
    {
        public static string PremiereLettreMaj(this string texte)
        {
            if (String.IsNullOrEmpty(texte))
            {
                return texte;
            }

            string resultatMin = texte.ToLower();
            resultatMin = resultatMin.Substring(0, 1).ToUpper() + resultatMin.Substring(1, resultatMin.Length - 1);
            return resultatMin;
        }
    }
}

