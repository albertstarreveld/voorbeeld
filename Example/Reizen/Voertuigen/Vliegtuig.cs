using System.Collections.Generic;
using System.Linq;
using Example.Reizen.Positie;
using Example.Reizen.Voertuigen.Zitplaatsen;

namespace Example.Reizen.Voertuigen
{
    public sealed class Vliegtuig : Voertuig
    {
        public int Hoogteligging { get; private set; }

        public override int MaximaleSnelheid => 1500;

        protected override IEnumerable<Zitplaats> Zitplaatsen { get; }

        public Vliegtuig(Coordinaten waarHetVliegtuigStaat) : base(waarHetVliegtuigStaat)
        {
            var zitplaatsen = new List<Zitplaats>();
            while (zitplaatsen.Count() < 100)
            {
                zitplaatsen.Add(new Zitplaats());
            }

            zitplaatsen.Add(new BestuurdersZitplaats());
            zitplaatsen.Add(new BestuurdersZitplaats()); // Voor de copiloot
            Zitplaatsen = zitplaatsen;
        }

        public override Coordinaten Stuur(Richting richting)
        {
            // Complete onzin natuurlijk, maar you get the picture.. Ik wil laten zien hoe je overriding kunt toepassen..
            // Snelheid heeft vandaag invloed op de hoogte van het vliegtuig..
            const int opsteigSnelheid = 300;
            Hoogteligging = Snelheid - opsteigSnelheid; 

            return base.Stuur(richting);
        }
        
    }
}