using System;

namespace Example.Reizen.Voertuigen.Zitplaatsen
{
    public class BestuurdersZitplaats : Zitplaats
    {
        public override void SetPersoon(Reiziger reiziger)
        {
            if (!(reiziger is Bestuurder))
            {
                throw new InvalidOperationException("Alleen bestuurders mogen hier zitten.");
            }

            base.SetPersoon(reiziger);
        }
    }
}