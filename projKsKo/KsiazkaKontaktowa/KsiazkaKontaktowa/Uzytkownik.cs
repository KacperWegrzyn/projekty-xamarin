using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using SQLite;
using System.IO;

namespace KsiazkaKontaktowa
{
    [Table("uzytkownik")]
    public class Uzytkownik
    {
        [PrimaryKey, AutoIncrement, Column("uzytkownik_id")]
        public int uzytkownik_id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string plec { get; set; }
        public string opis { get; set; }
        public string zdjecie { get; set; }
    }
}
