using System.Linq;
using Example.Reizen.Positie;
using Example.Reizen.Voertuigen;
using Example.Reizen.Voertuigen.Zitplaatsen;

namespace Example.Reizen
{
    public class Bestuurder : Reiziger
    {
        public void Bestuur(Voertuig voertuig, Coordinaten bestemming)
        {
            long afstand = 0;
            var richting = Richting.Noord;

            if (bestemming.X > voertuig.Positie.X)
            {
                afstand = bestemming.X - voertuig.Positie.X;
                richting = Richting.Oost;
            }

            if (bestemming.X < voertuig.Positie.X)
            {
                afstand = voertuig.Positie.X - bestemming.X;
                richting = Richting.West;
            }

            if (bestemming.Y > voertuig.Positie.Y)
            {
                afstand = bestemming.Y - voertuig.Positie.Y;
                richting = Richting.Noord;
            }

            if (bestemming.Y < voertuig.Positie.Y)
            {
                afstand = voertuig.Positie.Y - bestemming.Y;
                richting = Richting.Zuid;
            }

            while (afstand < voertuig.Snelheid)
            {
                voertuig.Rem();
            }

            while (afstand > voertuig.Snelheid && voertuig.Snelheid < voertuig.MaximaleSnelheid)
            {
                voertuig.Accellereer();
            }

            voertuig.Stuur(richting);
        }

        public override void StapIn(Voertuig voertuig, Zitplaats zitplaats)
        {
            if (!(zitplaats is BestuurdersZitplaats))
            {
                base.StapIn(voertuig, zitplaats);
                return;
            }

            var waarDePersoonWilGaanZitten = voertuig
                .BestuurdersPlaatsen
                .FirstOrDefault(x => x == zitplaats); // Zoek naar overeenkomende instance reference

            if (waarDePersoonWilGaanZitten == null)
            {
                throw new StoelOnbekendExceptie("Kan deze stoel niet vinden in dit voertuig.. Bent u wel in het juiste voertuig gestapt?");
            }

            zitplaats.SetPersoon(this);
        }
        
    }
}