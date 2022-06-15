using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;

namespace KsiazkaKontaktowa
{
    public partial class MainPage : ContentPage
    {
        private Uzytkownicy uzytkownicy = new Uzytkownicy();
        int od = 0;
        int numerStrony = 1;
        int maxrow;
        public MainPage()
        {
            InitializeComponent();
            odswiez();
        }

        public void odswiez()
        {
            if (list.IsChecked)
            {
                listView.ItemsSource = null;
                listView.ItemsSource = uzytkownicy.pobierzListe(od);
            }

            if (collection.IsChecked)
            {
                collectionView.ItemsSource = null;
                collectionView.ItemsSource = uzytkownicy.pobierzListe(od);
            }
            
            searchBar.Text = "";
        }

        private void poprzednia(object sender, EventArgs e)
        {
            Uzytkownicy u = new Uzytkownicy();

            od -= 5;
            numerStrony--;
            strona.Text = "Strona: " + numerStrony;

            odswiez();

            if (od <= 0)
            {
                poprzedni.IsEnabled = false;
            }
            nastepny.IsEnabled = true;
        }

        private void nastepna(object sender, EventArgs e)
        {
            Uzytkownicy u = new Uzytkownicy();

            od += 5;
            numerStrony++;
            strona.Text = "Strona: " + numerStrony;

            odswiez();
            maxrow = u.pobierz_ilosc_uzytkownikow().First().rownumber;

            if (maxrow - od <= 5)
            {
                nastepny.IsEnabled = false;
            }
            poprzedni.IsEnabled = true;
        }

        async void przycisk_dodaj(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DodajUzytkownika());
            odswiez();
        }

        private void przycisk_usun(object sender, EventArgs e)
        {
            Uzytkownik uzytkownik;

            if (list.IsChecked)
            {
                uzytkownik = listView.SelectedItem as Uzytkownik;
                if (uzytkownik is null) { }
                else
                {
                    uzytkownicy.usunUzytkownika(uzytkownik.uzytkownik_id);
                }
            }

            if (collection.IsChecked)
            {
                uzytkownik = collectionView.SelectedItem as Uzytkownik;
                if (uzytkownik is null) { }
                else
                {
                    uzytkownicy.usunUzytkownika(uzytkownik.uzytkownik_id);
                }
            }
            
            odswiez();
        }

        private async void przycisk_modyfikuj(object sender, EventArgs e)
        {
            Uzytkownik uzytkownik;

            if (list.IsChecked)
            {
                uzytkownik = listView.SelectedItem as Uzytkownik;
                if (uzytkownik is null) { }
                else
                {
                    await Navigation.PushAsync(new ModyfikujUzytkownika(uzytkownik));
                }
            }

            if (collection.IsChecked)
            {
                uzytkownik = collectionView.SelectedItem as Uzytkownik;
                if (uzytkownik is null) { }
                else
                {
                    await Navigation.PushAsync(new ModyfikujUzytkownika(uzytkownik));
                }
            }

            odswiez();
        }


        private async void przycisk_profil(object sender, EventArgs e)
        {
            Uzytkownik uzytkownik;

            if (list.IsChecked)
            {
                uzytkownik = listView.SelectedItem as Uzytkownik;
                if (uzytkownik is null) { }
                else
                {
                    await Navigation.PushAsync(new ProfilUzytkownika(uzytkownik));
                }
            }

            if (collection.IsChecked)
            {
                uzytkownik = collectionView.SelectedItem as Uzytkownik;
                if (uzytkownik is null) { }
                else
                {
                    await Navigation.PushAsync(new ProfilUzytkownika(uzytkownik));
                }
            }
        }
        
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchBar.Text == "")
            {
                odswiez();
            }
            else
            {
                List<Uzytkownik> lista = new List<Uzytkownik>();
                foreach (var u in uzytkownicy.pobierzCalaListe())
                {
                    string imieNazwisko = "";
                    if (u.imie != null)
                    {
                        imieNazwisko += u.imie;
                    }
                    if (u.nazwisko != null)
                    {
                        imieNazwisko += " ";
                        imieNazwisko += u.nazwisko;
                    }
                    if (imieNazwisko.Contains(searchBar.Text))
                    {
                        lista.Add(u);
                    }
                }

                if (list.IsChecked)
                {
                    listView.ItemsSource = null;
                    listView.ItemsSource = lista;
                }

                if (collection.IsChecked)
                {
                    collectionView.ItemsSource = null;
                    collectionView.ItemsSource = lista;
                }
            }
        }

        private void checkbox_list_change(object sender, CheckedChangedEventArgs e)
        {
            if (list.IsChecked)
            {
                listView.IsVisible = true;
                collectionView.IsVisible = false;
            }
            else
            {
                listView.IsVisible = false;
                collectionView.IsVisible = true;
            }
            odswiez();
        }


        private void checkbox_collection_change(object sender, CheckedChangedEventArgs e)
        {
            if (list.IsChecked)
            {
                listView.IsVisible = true;
                collectionView.IsVisible = false;
            }
            else
            {
                listView.IsVisible = false;
                collectionView.IsVisible = true;
            }
            odswiez();
        }
        
        
        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {

        }

    }
}
