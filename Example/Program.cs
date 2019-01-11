using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Example.Reizen;
using Example.Reizen.Positie;
using Example.Reizen.Voertuigen;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random(42);

            while (true)
            {
                // Setup..
                var huidigeLocatie = new Coordinaten(random.Next(1000), random.Next(1000));
                var bestemming = new Coordinaten(random.Next(1000), random.Next(1000));

                var bestuurder1 = new Bestuurder();
                var bestuurder2 = new Bestuurder();
                var passagier = new Reiziger();

                // Kies een voertuig en stap in
                var voertuigFactory = new VoertuigFactory();
                var voertuig = voertuigFactory.Create(huidigeLocatie, bestemming);
                bestuurder1.StapIn(voertuig, voertuig.BestuurdersPlaatsen.First());
                passagier.StapIn(voertuig, voertuig.PassagiersPlaatsen.First());

                if (voertuig is Vliegtuig)
                {
                    bestuurder2.StapIn(voertuig, voertuig.BestuurdersPlaatsen.Last()); // Wordt copiloot!
                }
                else
                {
                    bestuurder2.StapIn(voertuig,
                        voertuig.PassagiersPlaatsen.Last()); // Een auto heeft maar 1 bestuurdersplaats
                }

                // Vertrek naar het eindpunt
                voertuig.Start();
                while (!voertuig.Positie.Equals(bestemming))
                {
                    Console.WriteLine(
                        $"Op weg naar X: {bestemming.X} Y: {bestemming.Y}, nu op X: {voertuig.Positie.X}, Y:{voertuig.Positie.Y} met {voertuig.GetType()}");
                    bestuurder1.Bestuur(voertuig, bestemming);
                    Thread.Sleep(100);
                }

                Console.WriteLine(
                    $"Op weg naar X: {bestemming.X} Y: {bestemming.Y}, nu op X: {voertuig.Positie.X}, Y:{voertuig.Positie.Y} met {voertuig.GetType()}");
                Console.WriteLine("Gearriveerd!");

            }
        }
    }
}
