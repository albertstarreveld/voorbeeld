using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Reizen.Positie;

namespace Example.Reizen.Voertuigen
{
    public class VoertuigFactory
    {
        public Voertuig Create(Coordinaten huidigePositie, Coordinaten bestemming)
        {
            const int nearby = 500;

            var distance = huidigePositie.CalculateDistance(bestemming);
            if (distance < nearby)
            {
                return new Auto(huidigePositie);
            }

            return new Vliegtuig(huidigePositie);
        }

    }
}
