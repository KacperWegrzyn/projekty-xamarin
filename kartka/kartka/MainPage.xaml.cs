using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Timers;
using System.Threading;

namespace kartka
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var muzyka = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            muzyka.Load("muzyka1.mp3");
            muzyka.Loop = true;
            muzyka.Play();

            Task.Delay(250);
            patyk.AnchorX = 1;
            patyk.AnchorY = 1;

            Obracaj();
            Cien();
            Patyk();
            ZmieniajKolory();
        }

        int obrot = 0;
        int kolory = 0;
        
        private void Obracaj()
        {
            Device.StartTimer(new TimeSpan(300), () =>
            {
                obrot += 1;
                gwiazda.RotateTo(gwiazda.Rotation+1, 0, Easing.CubicInOut);

                kometa.TranslationX += 10;
                if(kometa.TranslationX >= 2000)
                {
                    kometa.TranslationX = -1000;
                }

                return true;
            });
        }

        private void ZmieniajKolory()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                kolory++;
                if (kolory == 1)
                {
                    lampka1.Fill = Brush.Yellow;
                    lampka2.Fill = Brush.Red;
                    lampka3.Fill = Brush.White;
                    lampka4.Fill = Brush.Yellow;
                    lampka5.Fill = Brush.Red;
                    lampka6.Fill = Brush.White;
                }

                if (kolory == 2)
                {
                    lampka2.Fill = Brush.Yellow;
                    lampka3.Fill = Brush.Red;
                    lampka1.Fill = Brush.White;
                    lampka5.Fill = Brush.Yellow;
                    lampka6.Fill = Brush.Red;
                    lampka4.Fill = Brush.White;
                }

                if (kolory == 3)
                {
                    lampka3.Fill = Brush.Yellow;
                    lampka1.Fill = Brush.Red;
                    lampka2.Fill = Brush.White;
                    lampka6.Fill = Brush.Yellow;
                    lampka4.Fill = Brush.Red;
                    lampka5.Fill = Brush.White;
                }

                if (kolory >= 3) { kolory = 0; }

                return true;
            });
        }
        

        async void Cien() {
            while (true)
            {
                if (cien.TranslationX >= 200)
                {
                    await cien.TranslateTo(200, 100, 4000);
                }
                
                if (cien.TranslationX <= 240)
                {
                    await cien.TranslateTo(240, 140, 4000);
                }
            }
        }

        async void Patyk()
        {
            while (true)
            {
                if (patyk.Rotation <= 40)
                {
                    await patyk.RotateTo(40, 1000);
                }

                if (patyk.Rotation >= 0)
                {
                    await patyk.RotateTo(0, 1000);
                }
            }
        }

        


    }
}
