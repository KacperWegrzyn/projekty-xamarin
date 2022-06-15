using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pizzeria
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Koszyk : ContentPage
    {
        ObservableCollection<Pizza> pizza = new ObservableCollection<Pizza>();
        public ObservableCollection<Pizza> Pizza { get { return pizza; } }

        public static int wartosc = 0;
        int staraWartosc = 0;
        int nowaWartosc = 0;

        public Koszyk()
        {
            InitializeComponent();
            Lista.ItemsSource = pizza;

            var id = MainPage.id;
            var nazwa = MainPage.nazwa;
            var opis = MainPage.opis;
            var cena = MainPage.cena;
            var zdj = MainPage.zdj;
            var ilosc = MainPage.ilosc;
            

            for (int i = 0; i < nazwa.Count; i++){
                pizza.Add(new Pizza { ID = i.ToString(), Id = id[i].ToString(), Nazwa = nazwa[i].ToString(), Opis = opis[i].ToString(), Zdj = zdj[i].ToString(), Cena = cena[i].ToString(), Ilosc = ilosc[i].ToString() });
                wartosc += int.Parse(cena[i]) * int.Parse(ilosc[i]);
            }

            doZaplaty.Text = wartosc.ToString();
        }

        async void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var result = await DisplayActionSheet("Co zrobić z produktem?", "Anuluj", null, "Zmień ilość", "Usuń", "Usuń wszystko");

            var item = e.Item as Pizza;

            var id = MainPage.id;
            var nazwa = MainPage.nazwa;
            var opis = MainPage.opis;
            var cena = MainPage.cena;
            var zdj = MainPage.zdj;
            var ilosc = MainPage.ilosc;

            staraWartosc = int.Parse(item.Cena) * int.Parse(item.Ilosc);


            if (result == "Usuń")
            {
                pizza.Remove(item);

                id.Remove(item.Id);
                nazwa.Remove(item.Nazwa);
                opis.Remove(item.Opis);
                cena.Remove(item.Cena);
                zdj.Remove(item.Zdj);
                ilosc.Remove(item.Ilosc);
            }

            if (result == "Zmień ilość")
            {
                var nowaIlosc = await Application.Current.MainPage.DisplayPromptAsync("Podaj ilość:", "", "Zmień", "Anuluj", initialValue: item.Ilosc, maxLength: 2, keyboard: Keyboard.Numeric);

                pizza.Remove(item);
                pizza.Add(new Pizza { ID = item.ID, Id = item.Id, Nazwa = item.Nazwa, Opis = item.Opis, Zdj = item.Zdj, Cena = item.Cena, Ilosc = nowaIlosc });
                
                nowaWartosc = int.Parse(item.Cena) * int.Parse(nowaIlosc);
            }

            wartosc -= staraWartosc;
            wartosc += nowaWartosc;

            if (result == "Usuń wszystko")
            {
                pizza.Clear();

                id.Clear();
                nazwa.Clear();
                opis.Clear();
                cena.Clear();
                zdj.Clear();
                ilosc.Clear();

                wartosc = 0;
            }

            doZaplaty.Text = wartosc.ToString();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var nazwa = MainPage.nazwa;

            if (nazwa.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Koszyk jest pusty", "Dodaj coś do koszyka", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await Navigation.PushAsync(new Formularz());
            }
        }
    }
}
