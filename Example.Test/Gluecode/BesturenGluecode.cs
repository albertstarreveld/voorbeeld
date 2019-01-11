using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Reizen;
using Example.Reizen.Positie;
using Example.Reizen.Voertuigen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;

namespace Example.Test.Gluecode
{
    [Binding]
    public class BesturenGluecode
    {
        private readonly long Coordinaat = TestHelper.CreateRandom<long>();

        private Coordinaten _positieBestemming;
        private Coordinaten _positieBestuurder;

        private Richting _gekozenRichting;

        [Given(@"de bestemming is in het (\S+)")]
        public void MaakBestemmingIn(string richting)
        {
            _positieBestemming = ParseRichting(richting);
        }

        [Given(@"de bestuurder is in het (\S+)")]
        public void MaakBestuurderIn(string richting)
        {
            _positieBestuurder = ParseRichting(richting);
        }

        [When("de bestuurder stuurt")]
        public void Stuur()
        {
            // Arrange
            var voertuigMock = new Mock<Voertuig>(_positieBestuurder);
            voertuigMock
                .Setup(x => x.Stuur(It.IsAny<Richting>()))
                .Callback<Richting>((r) => { _gekozenRichting = r; });
            
            var bestuurder = new Bestuurder();

            // Act
            bestuurder.Bestuur(voertuigMock.Object, _positieBestemming);
        }

        [Then(@"stuurt hij naar het (\w+)")]
        public void ControleerRichting(string richting)
        {
            Richting verwachteRichting;
            switch (richting)
            {
                case "noorden":
                    verwachteRichting = Richting.Noord;
                    break;
                case "zuiden":
                    verwachteRichting = Richting.Zuid;
                    break;
                case "oosten":
                    verwachteRichting = Richting.Oost;
                    break;
                case "westen":
                    verwachteRichting = Richting.West;
                    break;
                default:
                    throw new NotSupportedException($"Hoe de richting {richting} gecontroleerd kan worden is nog niet geimplementeerd in de test.");
            }

            Assert.AreEqual(verwachteRichting, _gekozenRichting);
        }


        private Coordinaten ParseRichting(string richting)
        {
            var inHetMidden = Coordinaat / 2;
            var verWeg = Coordinaat;
            var dichtBij = 0;
            switch (richting)
            {
                case "noorden":
                    return new Coordinaten(x: inHetMidden, y: verWeg);
                case "zuiden":
                    return new Coordinaten(x: inHetMidden, y: dichtBij);
                case "oosten":
                    return new Coordinaten(x: verWeg, y: inHetMidden);
                case "westen":
                    return new Coordinaten(x: dichtBij, y: inHetMidden);
                case "noord-westen":
                    return new Coordinaten(x: dichtBij, y: verWeg);
                case "zuid-oosten":
                    return new Coordinaten(x: verWeg, y: dichtBij);
                default:
                    throw new NotSupportedException($"Hoe om te gaan met richting {richting} is nog niet geimplementeerd in de test.");
            }
        }
    }
}
