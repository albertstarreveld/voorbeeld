using System;

namespace Example.Reizen.Voertuigen.Zitplaatsen
{
    public class StoelOnbekendExceptie : Exception
    {
        public StoelOnbekendExceptie(string bericht) : base(bericht) { }
    }
}