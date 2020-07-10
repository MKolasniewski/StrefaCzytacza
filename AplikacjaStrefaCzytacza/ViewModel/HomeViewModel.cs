using AplikacjaStrefaCzytacza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplikacjaStrefaCzytacza.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Cytat> Cytaty { get; set; }
        public IEnumerable<Ksiazka> Ksiazki { get; set; }
        public IEnumerable<Kategoria> Kategorie { get; set; }
    }
}