namespace Example.Reizen.Voertuigen.Zitplaatsen
{
    public class Zitplaats
    {
        public Reiziger Reiziger { get; private set; }

        public virtual void SetPersoon(Reiziger reiziger)
        {
            if (Reiziger != null)
            {
                throw new StoelBezetExceptie("Hier zit al iemand.");
            }

            Reiziger = reiziger;
        }
    }
}