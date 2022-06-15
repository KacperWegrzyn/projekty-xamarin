using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using SQLite;
using System.IO;

namespace KsiazkaKontaktowa
{
    [Table("rownumber")]
    public class Rownumber
    {
        [PrimaryKey, AutoIncrement, Column("rownumber")]
        public int rownumber { get; set; }
    }
}
