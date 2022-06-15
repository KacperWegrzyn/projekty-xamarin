using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KsiazkaKontaktowa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilUzytkownika : ContentPage
    {
        Uzytkownik u;
        public ProfilUzytkownika(Uzytkownik u)
        {
            InitializeComponent();
            this.u = u;
            imie_nazwisko.Text = $"{u.imie} {u.nazwisko}";
            opis.Text = u.opis;

            if (u.plec == "m")
            {
                plec.Text = "Mężczyzna";
            }
            else if (u.plec == "k")
            {
                plec.Text = "Kobieta";
            }
            zdjecie.Source = u.zdjecie;
        }
    }
}