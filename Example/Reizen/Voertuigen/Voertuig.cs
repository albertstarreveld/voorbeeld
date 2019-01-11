using System;
using System.Collections.Generic;
using System.Linq;
using Example.Reizen.Positie;
using Example.Reizen.Voertuigen.Zitplaatsen;

namespace Example.Reizen.Voertuigen
{
    public abstract class Voertuig
    {
        public VoertuigStatus VoertuigStatus { get; protected set; } = VoertuigStatus.Gestopt;

        public int Snelheid { get; private set; }

        public Coordinaten Positie { get; private set; }
        
        public IEnumerable<Zitplaats> BestuurdersPlaatsen => Zitplaatsen
                                            .OfType<BestuurdersZitplaats>()
                                            .ToArray();

        public IEnumerable<Zitplaats> PassagiersPlaatsen => Zitplaatsen
                                            .Where(x => !(x is BestuurdersZitplaats))
                                            .ToArray();

        public Reiziger Bestuurder => BestuurdersPlaatsen
                                            .Where(x => x.Reiziger != null && x is BestuurdersZitplaats)
                                            .Select(x => x.Reiziger)
                                            .FirstOrDefault();

        protected virtual int MinimaalAantalBestuurders => 1;

        public abstract int MaximaleSnelheid { get; }

        protected abstract IEnumerable<Zitplaats> Zitplaatsen { get; }

        protected Voertuig(Coordinaten waarHetVoertuigStaat)
        {
            Positie = waarHetVoertuigStaat;
        }

        public virtual void Start()
        {
            if (Zitplaatsen.Any(x => x is BestuurdersZitplaats && x.Reiziger == null))
            {
                throw new InvalidOperationException("Kan niet vertrekken zonder de bestuurder(s).");
            }
            
            VoertuigStatus = VoertuigStatus.Gestart;
        }

        public virtual void Stop()
        {
            VoertuigStatus = VoertuigStatus.Gestopt;
        }

        public int Accellereer()
        {
            if (Snelheid != MaximaleSnelheid)
            {
                Snelheid++;
            }

            return Snelheid;
        }

        public int Rem()
        {
            if (Snelheid != 0)
            {
                Snelheid--;
            }

            return Snelheid;
        }

        public virtual Coordinaten Stuur(Richting richting)
        {
            if (VoertuigStatus != VoertuigStatus.Gestart)
            {
                return Positie;
            }

            switch (richting)
            {
                case Richting.Noord:
                    Positie = new Coordinaten(Positie.X, Positie.Y + Snelheid);
                    break;
                case Richting.Oost:
                    Positie = new Coordinaten(Positie.X + Snelheid, Positie.Y);
                    break;
                case Richting.West:
                    Positie = new Coordinaten(Positie.X - Snelheid, Positie.Y);
                    break;
                case Richting.Zuid:
                    Positie = new Coordinaten(Positie.X, Positie.Y - Snelheid);
                    break;
                default:
                    throw new NotSupportedException($"Kan richting {richting} niet verwerken.");
            }

            return Positie;
        }
    }
}