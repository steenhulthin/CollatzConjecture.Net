using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CollatzConjecture
{
    [TestFixture]
    public sealed class TestNumberOfStepsToOne
    {
        [Test]
        public void TestThatTheNumberOfStepsFromOneToOneIsZero()
        {
            Assert.That(new Collatz().StepsToOne(1), Is.EqualTo(0));
        }

        [Test]
        public void TestThatTheNumberOfStepsFromTwoToOneIsOne()
        {
            Assert.That(new Collatz().StepsToOne(2), Is.EqualTo(1));
        }

        [Test]
        public void TestThatTheNumberOfStepsFromThreeToOneIsSeven()
        {
            Assert.That(new Collatz().StepsToOne(3), Is.EqualTo(7));
        }

        [Test]
        public void TestThatNextNumberIsHalfWhenEven()
        {
            Assert.That(new Collatz().NextNumber(2), Is.EqualTo(1));
        }

        [Test]
        public void TestThatNextNumberIsThreeTimesPlusOneWhenOdd()
        {
            Assert.That(new Collatz().NextNumber(3), Is.EqualTo(10));
        }
    }

    public class Collatz
    {
        public int StepsToOne(int i)
        {
            if(i == 1)
                return 0;
            return 1 + StepsToOne(NextNumber(i));
        }

        public int NextNumber(int i)
        {
            return i % 2 == 0 ? i / 2 : (3 * i) + 1;
        }
    }
}
