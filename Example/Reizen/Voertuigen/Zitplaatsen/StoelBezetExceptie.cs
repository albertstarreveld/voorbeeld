using System;

namespace Example.Reizen.Voertuigen.Zitplaatsen
{
    public class StoelBezetExceptie : Exception
    {
        public StoelBezetExceptie(string bericht) : base(bericht) { }
    }
}