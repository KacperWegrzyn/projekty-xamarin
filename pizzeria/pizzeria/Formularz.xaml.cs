using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pizzeria
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formularz : ContentPage
    {
        public Formularz()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var szczegoly = imie.Text + " " + nazwisko.Text + "\n" + numer.Text + "\n" + adres.Text + "\n\n" + Koszyk.wartosc + " zł";

            await Application.Current.MainPage.DisplayAlert("Zamówienie zostało przyjęte", szczegoly, "OK");
            await Navigation.PushAsync(new MainPage());
           
            var id = MainPage.id;
            var nazwa = MainPage.nazwa;
            var opis = MainPage.opis;
            var cena = MainPage.cena;
            var zdj = MainPage.zdj;
            var ilosc = MainPage.ilosc;

            id.Clear();
            nazwa.Clear();
            opis.Clear();
            cena.Clear();
            zdj.Clear();
            ilosc.Clear();

            Koszyk.wartosc = 0;
        }
    }
}