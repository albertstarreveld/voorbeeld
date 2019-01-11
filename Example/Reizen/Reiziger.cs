using System;
using System.Linq;
using System.Threading.Tasks;
using Example.Reizen.Voertuigen;
using Example.Reizen.Voertuigen.Zitplaatsen;

namespace Example.Reizen
{
    public class Reiziger
    {
        public virtual void StapIn(Voertuig voertuig, Zitplaats zitplaats)
        {
            var waarDePersoonWilGaanZitten = voertuig
                .PassagiersPlaatsen
                .FirstOrDefault(x => x == zitplaats); // Zoek naar overeenkomende instance reference

            if (waarDePersoonWilGaanZitten == null)
            {
                throw new StoelOnbekendExceptie("Kan deze stoel niet vinden in dit voertuig.. Bent u wel in het juiste voertuig gestapt?");
            }

            zitplaats.SetPersoon(this);
        }
    }
}