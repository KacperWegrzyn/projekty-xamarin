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
    public partial class ModyfikujUzytkownika : ContentPage
    {
        private Uzytkownicy uzytkownicy = new Uzytkownicy();
        Uzytkownik u;
        private string zdjecie;
        private int uzytkownik_id;
        string _imie, _nazwisko, _plec, _opis;

        public ModyfikujUzytkownika(Uzytkownik u)
        {
            InitializeComponent();
            this.u = u;

            uzytkownik_id = u.uzytkownik_id;
            imie.Text = u.imie;
            nazwisko.Text = u.nazwisko;
            opis.Text = u.opis;
            zdjecie = u.zdjecie;

            if(u.plec == "m")
            {
                m.IsChecked = true;
            }
            else if(u.plec == "k")
            {
                k.IsChecked = true;
            }

            _imie = u.imie;
            _nazwisko = u.nazwisko;
            _plec = u.plec;
            _opis = u.opis;
        }

        public ModyfikujUzytkownika(Uzytkownik u, string zdjecie, int uzytkownik_id, string imie, string nazwisko, string plec, string opis)
        {
            InitializeComponent();
            this.u = u;
            this.zdjecie = zdjecie;
            this.imie.Text = imie;
            this.nazwisko.Text = nazwisko;
            this.opis.Text = opis;
            this.uzytkownik_id = uzytkownik_id;

            if (plec == "m")
            {
                m.IsChecked = true;
            }
            else if (plec == "k")
            {
                k.IsChecked = true;
            }
        }

        private async void przycisk_modyfikuj(object sender, EventArgs e)
        {
            MainPage mp = new MainPage();

            this.u.uzytkownik_id = uzytkownik_id;
            this.u.imie = imie.Text;
            this.u.nazwisko = nazwisko.Text;
            this.u.opis = opis.Text;
            this.u.zdjecie = zdjecie;

            if (m.IsChecked)
            {
                this.u.plec = "m";
            }
            else if (k.IsChecked)
            {
                this.u.plec = "k";
            }

            
            uzytkownicy.modyfikujUzytkownika(u);
            mp.odswiez();
            await Navigation.PushAsync(new MainPage());
        }

        private async void przycisk_galeria(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Galeria("ModyfikujUzytkownika", uzytkownik_id, _imie, _nazwisko, _plec, _opis, zdjecie, u));
        }
    }
}