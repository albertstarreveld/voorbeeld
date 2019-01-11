using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace Example.Test
{
    public static class TestHelper
    {
        public static T CreateRandom<T>()
        {
            var fixture = new Fixture();
            return fixture.Create<T>();
        }

        public static T CreateRandom<T>(long min, long max)
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(min, max));
            return fixture.Create<T>();
        }
    }
}
