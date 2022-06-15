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
    public partial class DodajUzytkownika : ContentPage
    {
        private Uzytkownicy uzytkownicy = new Uzytkownicy();
        public string zdjecie = "zdj0.jpg";
        string _imie, _nazwisko, _plec, _opis;

        public DodajUzytkownika()
        {
            InitializeComponent();
        }

        public DodajUzytkownika(string zdjecie, string imie, string nazwisko, string plec, string opis)
        {
            InitializeComponent();
            this.zdjecie = zdjecie;
            this.imie.Text = imie;
            this.nazwisko.Text = nazwisko;
            this.opis.Text = opis;

            if (plec == "m")
            {
                m.IsChecked = true;
            }
            else if (plec == "k")
            {
                k.IsChecked = true;
            }
        }

        private async void przycisk_dodaj(object sender, EventArgs e)
        {
            Uzytkownik u = new Uzytkownik();
            MainPage mp = new MainPage();

            u.imie = imie.Text;
            u.nazwisko = nazwisko.Text;
            u.opis = opis.Text;
            u.zdjecie = "zdj0.jpg";

            if(m.IsChecked)
            {
                u.plec = "m";
            }
            else if(k.IsChecked)
            {
                u.plec = "k";
            }

            if (zdjecie != "zdj0.jpg" && zdjecie != "")
            {
                u.zdjecie = zdjecie;
            }

            uzytkownicy.dodajUzytkownika(u);
            mp.odswiez();
            await Navigation.PushAsync(new MainPage());
        }

        private async void przycisk_galeria(object sender, EventArgs e)
        {
            _imie = imie.Text;
            _nazwisko = nazwisko.Text;
            _opis = opis.Text;

            if (m.IsChecked)
            {
                _plec = "m";
            }
            else if (k.IsChecked)
            {
                _plec = "k";
            }

            await Navigation.PushAsync(new Galeria("DodajUzytkownika", _imie, _nazwisko, _plec, _opis));
        }
    }
}