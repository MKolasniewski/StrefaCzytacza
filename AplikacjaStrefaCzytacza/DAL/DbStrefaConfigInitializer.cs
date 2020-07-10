using AplikacjaStrefaCzytacza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AplikacjaStrefaCzytacza.DAL
{
    public class DbStrefaConfigInitializer : CreateDatabaseIfNotExists<DbStrefaConfig>
    {
        protected override void Seed(DbStrefaConfig context)
        {
            SeedDbContextConfig(context);
            base.Seed(context);
        }

        private void SeedDbContextConfig(DbStrefaConfig context)
        {
            var kategoria = new List<Kategoria>
            {

                new Kategoria() {Id=1,NazwaKategorii="biografia",OpisKategorii="Wspomnienia, pamiętniki, autobiografie"},
                new Kategoria() {Id=2,NazwaKategorii="historia",OpisKategorii="Historia Polski, Europy, Świata, Historia narodów, ludności. Historia starożytna. Średniowiecze"},
                new Kategoria() {Id=3,NazwaKategorii="filozofia",OpisKategorii="Metafizyka, życie, religia, natura"},
                new Kategoria() {Id=4,NazwaKategorii="astropsychologia",OpisKategorii="Połączenie doświadczeń starożytnej i współczesnej psychologii. Próba pogodzenia ze sobą tradycji naukowej i ezoterycznej"},
                new Kategoria() {Id=5,NazwaKategorii="bajki",OpisKategorii="Bajka, jedna z najstarszych form literackich, wywodzi się z oralnej tradycji ludowej i jest wspólna wszystkim kulturom, co poświadczają zabytki, które przetrwały do dzisiejszych czasów, choćby w formie szczątkowej."},
                new Kategoria() {Id=6,NazwaKategorii="romans",OpisKategorii="Romans erotyczny, historyczny,kryminalny, new adult, paranormalny/fantastyczny, współczesny"},
                new Kategoria() {Id=7,NazwaKategorii="fantastyka",OpisKategorii="Gatunek, którego głównym motywem przewodnim są magia i inne nadprzyrodzone elementy. Zazwyczaj akcja powieści czy opowiadania rozgrywa się w świecie odrębnym od świata realnego."},
                new Kategoria() {Id=8,NazwaKategorii="dieta",OpisKategorii="Zdrowie, uroda, kulinaria, dietetyka, kucharstwo, otyłość, ziołolecznictwo"}
            };
            kategoria.ForEach(k => context.Kategorias.Add(k));
            context.SaveChanges();

        }
    }
}