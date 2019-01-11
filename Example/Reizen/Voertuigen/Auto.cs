using System.Collections.Generic;
using Example.Reizen.Positie;
using Example.Reizen.Voertuigen.Zitplaatsen;

namespace Example.Reizen.Voertuigen
{
    public sealed class Auto : Voertuig
    {
        public override int MaximaleSnelheid => 200;

        protected override IEnumerable<Zitplaats> Zitplaatsen { get; }

        public Auto(Coordinaten waarDeAutoStaat) : base(waarDeAutoStaat)
        {
            Zitplaatsen = new[]
            {
                new BestuurdersZitplaats(),
                new Zitplaats(),
                new Zitplaats(),
                new Zitplaats(),
                new Zitplaats()
            };
        }
    }
}