using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace pizzeria
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Pizza> pizza = new ObservableCollection<Pizza>();
        public ObservableCollection<Pizza> Pizza { get { return pizza; } }


        string[] Nazwa =
        {
            "Margarita",
            "Domowa",
            "Italiano",
            "Wiejska",
            "Staropolska",
            "Salami",
            "Dominikana",
            "Classic",
            "Regina",
            "Hawajska",
            "Wegetariańska",
            "Carbona",
            "Capriccioza",
            "Matador",
            "Roma",
            "Amigo"
        };

        string[] Opis =
        {
            "szynka, ser, pomidor",
            "pieczarki, pomidor, pepperoni",
            "oliwki, kurczak, parmezan",
            "ser, groszek, oregano",
            "ser, szynka, ananas, oregano",
            "pieczarki, boczek, pomidor",
            "ser, pieczarki, kukurydza, cebula",
            "ser, groszek, oregano",
            "ser, szynka, ananas, oregano",
            "pieczarki, boczek, pomidor",
            "szynka, wołowina, wieprzowina, kurczak",
            "szynka, ser, pomidor",
            "pieczarki, pomidor, pepperoni",
            "oliwki, kurczak, parmezan",
            "ser, groszek, oregano",
            "ser, szynka, ananas, oregano",
        };

        int[] Cena =
        {
            20,
            18,
            25,
            22,
            23,
            25,
            26,
            20,
            18,
            25,
            22,
            23,
            25,
            26,
            24,
            20
        };

        string[] Zdj =
        {
            "https://www.mojegotowanie.pl/media/cache/default_view/uploads/media/recipe/0002/19/pizza-z-salami.jpeg",
            "https://www.oetker.pl/Recipe/Recipes/oetker.pl/pl-pl/miscellaneous/image-thumb__51050__RecipeDetail/pizza-domowa.jpg",
            "https://images.aws.nestle.recipes/resized/688b9bae3770ad72f10b6e4aa2206a98_pizza_hawajska_10_944_531.jpg",
            "https://www.vibesofindia.com/wp-content/uploads/2021/12/pizza.jpg",
            "https://sliceofheaven.pl/wp-content/uploads/2021/01/pizza-Wroclaw-najlepsza.jpg",
            "https://media-cdn.tripadvisor.com/media/photo-s/11/df/4c/63/pizza-fresca-pierwszy.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNWVlZxNHxQI5YXCbL8o5_qxkf0K7Q-W9cfw&usqp=CAU",
            "https://static.toiimg.com/thumb/56933159.cms?imgsize=686279&width=800&height=800",
            "https://media.istockphoto.com/photos/delicious-vegetarian-pizza-on-white-picture-id1192094401?k=20&m=1192094401&s=612x612&w=0&h=jesvXuPyvqM36GQ5QEvJrL3QZjK6YKsziUUF3ZbW0gw=",
            "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/697B6817-CEDE-4D44-A968-FCBEED0A035C/Derivates/7f0a3782-933f-4f51-83c6-89b60216bc70.jpg",
            "https://kuchnialidla.pl/img/PL/960x540/c57a56238c1d-fbc1097428af-123_KUCHNIA_LIDLA_KAROL_19012021_4438_Pizza_Chicago_1250x700.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDkWsIInhUeAnK-bvK5LMo_qIbj5kY8yiTcA&usqp=CAU",
            "https://media.istockphoto.com/photos/tasty-pepperoni-pizza-and-cooking-ingredients-tomatoes-basil-on-black-picture-id1083487948?k=20&m=1083487948&s=612x612&w=0&h=ROZ5t1K4Kjt5FQteVxTyzv_iqFcX8aqpl7YuA1Slm7w=",
            "https://www.pyszne.pl/foodwiki/uploads/sites/7/2018/03/pizza-3.jpg",
            "https://images.aws.nestle.recipes/resized/4274048cd5f17c49dfee280f77a3739d_Cheese-Pizza_HB-2_944_531.jpg",
            "https://tmbidigitalassetsazure.blob.core.windows.net/rms3-prod/attachments/37/1200x1200/Pizza-from-Scratch_EXPS_FT20_8621_F_0505_1_home.jpg"
        };

        public MainPage()
        {
            InitializeComponent();

            Lista.ItemsSource = pizza;

            for (int i = 0; i < Nazwa.Length; i++){
                pizza.Add(new Pizza { Id = i.ToString(), Nazwa = Nazwa[i], Opis = Opis[i], Zdj = Zdj[i], Cena = Cena[i].ToString() });
            }
        }

        public static List<string> id = new List<string>();
        public static List<string> nazwa = new List<string>();
        public static List<string> opis = new List<string>();
        public static List<string> cena = new List<string>();
        public static List<string> zdj = new List<string>();
        public static List<string> ilosc = new List<string>();

        async void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var dodane = await Application.Current.MainPage.DisplayAlert("Dodać do koszyka?", "", "Dodaj", "Anuluj");

            if (dodane)
            {
                var item = e.Item as Pizza;

                if (!nazwa.Contains(item.Nazwa))
                {
                    id.Add(item.Id);
                    nazwa.Add(item.Nazwa);
                    opis.Add(item.Opis);
                    cena.Add(item.Cena);
                    zdj.Add(item.Zdj);
                    ilosc.Add(await Application.Current.MainPage.DisplayPromptAsync("Podaj ilość:", "", "Dodaj", "", initialValue: "1", maxLength: 2, keyboard: Keyboard.Numeric));
                }
                else
                {
                    var ktore = await Application.Current.MainPage.DisplayAlert("Pizza już jest w koszyku", "", "OK", "Przejdź do koszyka");

                    if (!ktore)
                    {
                        await Navigation.PushAsync(new Koszyk());
                    }
                }

            }

            ((ListView)sender).SelectedItem = null;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Koszyk());
        }
    }
}
