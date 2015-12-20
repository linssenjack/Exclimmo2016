using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclimmo2016.Models
{
    public class Pand
    {
        public int Id { get; set; }
        public Soort Soort { get; set; }
        public TransactieType TransactieType { get; set; }
        public string Beschrijving { get; set; }
        public string Locatie { get; set; }
        public string ImageUrl { get; set; }
    }

    public enum Soort
    {
        Alles, 
        Villa,
        Kasteel,
        GolfVilla,
        LuxeAppartement,
        Residentie,
        Loft
    }

    public enum TransactieType
    {
        Huren,
        Kopen,
        Beiden
    }


    public class ExclimmoContext : DbContext
    {
        public ExclimmoContext() : base("DefaultConnection")
        {
        }

        public DbSet<Pand> Panden { get; set; }


        public void SeedPanden()
        {
            // sentinel
            if (Panden.Any()) return;
            Panden.Add(new Pand
            {
                Beschrijving = "Mooie villa te Gentbrugge",
                Locatie = "Gentbrugge",
                Soort = Soort.Villa,
                TransactieType = TransactieType.Kopen,
                ImageUrl = "villa.jpg"
            });
            Panden.Add(new Pand
            {
                Beschrijving = "Mooie kasteel te Merelbeke",
                Locatie = "Merelbeke",
                Soort = Soort.Kasteel,
                TransactieType = TransactieType.Huren,
            });
            Panden.Add(new Pand
            {
                Beschrijving = "Prachtige Loft te Sint-Amandsberg",
                Locatie = "Sint-Amandsberg",
                Soort = Soort.Loft,
                TransactieType = TransactieType.Beiden,
                ImageUrl = "loft.jpg"
            });
            // Wijzigingen in de context wegschrijven.
            SaveChanges();
        }
    }
}
