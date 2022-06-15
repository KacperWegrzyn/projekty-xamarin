using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace KsiazkaKontaktowa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Galeria : ContentPage
    {
        Uzytkownik uzytkownik;

        public string zdjecie;
        private string klasa;
        public int uzytkownik_id;
        public string _imie, _nazwisko, _plec, _opis;
        int ilosc_plikow = 7;

        public Galeria(string klasa, string imie, string nazwisko, string plec, string opis)
        {
            InitializeComponent();
            this.klasa = klasa;
            znajdz_zdjecia3();

            _imie = imie;
            _nazwisko = nazwisko;
            _plec = plec;
            _opis = opis;
        }

        public Galeria(string klasa, int uzytkownik_id, string imie, string nazwisko, string plec, string opis, string zdjecie, Uzytkownik u)
        {
            InitializeComponent();
            this.klasa = klasa;
            znajdz_zdjecia3();

            this.uzytkownik_id = uzytkownik_id;
            _imie = imie;
            _nazwisko = nazwisko;
            _plec = plec;
            _opis = opis;
            this.zdjecie = zdjecie;

            this.uzytkownik = u;
        }

        private void wpisz_zdjecia()
        {
            List<Zdjecie> zdjecia = new List<Zdjecie>();
            zdjecia.Add(new Zdjecie() { zdj_id = 0, zdj_nazwa = "zdj0.jpg" });
            zdjecia.Add(new Zdjecie() { zdj_id = 1, zdj_nazwa = "zdj1.jpg" });
            zdjecia.Add(new Zdjecie() { zdj_id = 2, zdj_nazwa = "zdj2.jpg" });
            zdjecia.Add(new Zdjecie() { zdj_id = 3, zdj_nazwa = "zdj3.jpg" });
            zdjecia.Add(new Zdjecie() { zdj_id = 4, zdj_nazwa = "zdj4.jpg" });
            zdjecia.Add(new Zdjecie() { zdj_id = 5, zdj_nazwa = "zdj5.jpg" });
            carouselView.ItemsSource = zdjecia;
        }

        private async void btn_Clicked(object sender, EventArgs e)
        {
            Zdjecie ci = (Zdjecie)carouselView.CurrentItem;
            label.Text = ci.zdj_nazwa.ToString();
            zdjecie = ci.zdj_nazwa.ToString();

            if (klasa == "DodajUzytkownika")
            {
                await Navigation.PushAsync(new DodajUzytkownika(zdjecie, _imie, _nazwisko, _plec, _opis));
            }
            if (klasa == "ModyfikujUzytkownika")
            {
                await Navigation.PushAsync(new ModyfikujUzytkownika(uzytkownik, zdjecie, uzytkownik_id, _imie, _nazwisko, _plec, _opis));
            }
        }

        private void carouselView_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            Zdjecie ci = (Zdjecie)carouselView.CurrentItem;
            label.Text = ci.zdj_nazwa.ToString();
        }

        private void znajdz_zdjecia3()
        {
            List<Zdjecie> zdjecia = new List<Zdjecie>();
            
            for(int id=0; id<ilosc_plikow; id++)
            {
                zdjecia.Add(new Zdjecie() { zdj_id = id, zdj_nazwa = $"zdj{id}.jpg" });
            }
            carouselView.ItemsSource = zdjecia;
        }

        private void znajdz_zdjecia()
        {
            //var folder = @"C:/Users/Kacper/Desktop/0000000/projKsKo/KsiazkaKontaktowa/KsiazkaKontaktowa.Android/Resources/drawable";
            ////var folder = Path.Combine(FileSystem.AppDataDirectory, "drawable");
            //var pliki = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            //int i = 1;
            ////List<string> zdjecia = new List<string>();
            //List<Zdjecie> zdjecia = new List<Zdjecie>();
            //foreach (string nazwa in pliki)
            //{
            //    //if (Regex.IsMatch(nazwa, @"\.jpg$|\.png$"))
            //        //zdjecia.Add(nazwa);
            //    zdjecia.Add(new Zdjecie() { zdj_id = i, zdj_nazwa = nazwa });
            //    i++;
            //}

            
        }

        private void znajdz_zdjecia2()
        {
            //var d = Path.GetFileName(@"C:\img");
            //var pliki = Directory.GetFiles(d, "*.jpg");
            //string[] Files = Directory.GetFiles(@"C:\img\", "*.jpg");
            //List<Zdjecie> zdjecia = new List<Zdjecie>();
            //int i = 1;
            //string str = "";
            //foreach (string file in Files)
            //{
                //zdjecia.Add(new Zdjecie() { zdj_id = i, zdj_nazwa = file.Name });
                //i++;
                //str = str + ", " + file;
            //}

            //DirectoryInfo d = new DirectoryInfo(@"C:\img");
            //FileInfo[] Files = d.GetFiles();
            //foreach (FileInfo file in Files)
            //{
            //    str += file.Name;
            //}
        }


        //public static String[] GetFilesFrom(String folder, String[] rozszerzenia, bool isRecursive)
        //{
        //    List<String> filesFound = new List<String>();
        //    var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        //    foreach (var filter in rozszerzenia)
        //    {
        //        filesFound.AddRange(Directory.GetFiles(folder, String.Format("*.{0}", filter), searchOption));
        //    }
        //    return filesFound.ToArray();
        //}

        private void CarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {

        }

        
    }
}