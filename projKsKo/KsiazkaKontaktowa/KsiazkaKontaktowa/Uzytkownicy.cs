using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using SQLite;
using System.IO;

namespace KsiazkaKontaktowa
{
    class Uzytkownicy
    {
        private SQLiteConnection connection;
        public Uzytkownicy()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "database.db");    
            connection = new SQLiteConnection(databasePath);
            connection.CreateTable<Uzytkownik>();
        }
        ~Uzytkownicy()
        {
            connection.Close();
        }

        public List<Uzytkownik> pobierzCalaListe()
        {
            var listaUzytkownikow = connection.Table<Uzytkownik>().ToList();
            return listaUzytkownikow;
        }

        public List<Uzytkownik> pobierzListe(int od)
        {
            var listaUzytkownikow = WybierzZBazy(connection, od) as List<Uzytkownik>;
            return listaUzytkownikow;
        }

        public void dodajUzytkownika(Uzytkownik u)
        {
            Uzytkownik uzytkownik = new Uzytkownik
            {
                uzytkownik_id = u.uzytkownik_id,
                imie = u.imie,
                nazwisko = u.nazwisko,
                plec = u.plec,
                opis = u.opis,
                zdjecie = u.zdjecie
            };
            connection.Insert(uzytkownik);
        }

        public void usunUzytkownika(int uzytkownik_id)
        {
            connection.Delete<Uzytkownik>(uzytkownik_id);
        }
        
        public void modyfikujUzytkownika(Uzytkownik u)
        {
            connection.Execute($@"UPDATE uzytkownik SET imie='{u.imie}', nazwisko='{u.nazwisko}', plec='{u.plec}', opis='{u.opis}', zdjecie='{u.zdjecie}' WHERE uzytkownik_id='{u.uzytkownik_id}'");
        }

        public static IEnumerable<Uzytkownik> WybierzZBazy(SQLiteConnection connection, int od)
        {
            return connection.Query<Uzytkownik>($@"SELECT * FROM uzytkownik LIMIT 5 OFFSET {od}");
        }

        public static IEnumerable<Rownumber> oblicz_ilosc_uzytkownikow(SQLiteConnection connection)
        {
            return connection.Query<Rownumber>("SELECT row_number() over(ORDER BY uzytkownik_id) AS rownumber FROM `uzytkownik` ORDER BY rownumber DESC LIMIT 1");
        }

        public List<Rownumber> pobierz_ilosc_uzytkownikow()
        {
            var rownumber = oblicz_ilosc_uzytkownikow(connection) as List<Rownumber>;
            return rownumber;
        }
    }
}
