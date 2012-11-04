using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CollatzConjecture
{
    [TestFixture]
    public sealed class TestNumberOfStepsToOne
    {
        [Test]
        public void TestThatTheNumberOfStepsFromOneToOneIsZero()
        {
            Assert.That(new Collatz().StepsToCollatzNumberOneRecursive(1), Is.EqualTo(0));
        }

        [Test]
        public void TestThatTheNumberOfStepsFromTwoToOneIsOne()
        {
            Assert.That(new Collatz().StepsToCollatzNumberOneRecursive(2), Is.EqualTo(1));
        }

        [Test]
        public void TestThatTheNumberOfStepsFromThreeToOneIsSeven()
        {
            Assert.That(new Collatz().StepsToCollatzNumberOneRecursive(3), Is.EqualTo(7));
        }

        [Test]
        public void TestThatTheNumberOfStepsFromOneToOneIsZeroWithNonrecursive()
        {
            Assert.That(new Collatz().StepsToCollatzNumberOneNonRecursive(1), Is.EqualTo(0));
        }

        [Test]
        public void TestThatTheNumberOfStepsFromTwoToOneIsOneWithNonrecursive()
        {
            Assert.That(new Collatz().StepsToCollatzNumberOneNonRecursive(2), Is.EqualTo(1));
        }

        [Test]
        public void TestThatTheNumberOfStepsFromThreeToOneIsSevenWithNonrecursive()
        {
            Assert.That(new Collatz().StepsToCollatzNumberOneNonRecursive(3), Is.EqualTo(7));
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

        [Test]
        public void TestThatTheSequenceToOneReturnsOneIfNumberIsOne()
        {
            Assert.That(new Collatz().SequenceToCollatzNumberOne(1), Is.AssignableTo<IEnumerable<int>>());
            Assert.That(new Collatz().SequenceToCollatzNumberOne(1).First(), Is.EqualTo(1));
        }

        [Test]
        public void TestThatTheSequenceToOneReturnsEightFourTwoOneIfNumberIsEight()
        {
            Assert.That(new Collatz().SequenceToCollatzNumberOne(8), Is.EquivalentTo(new[]{8,4,2,1}));
        }


    }

    public class Collatz
    {
        public int StepsToCollatzNumberOneRecursive(int i)
        {
            if(i == 1)
                return 0;
            return 1 + StepsToCollatzNumberOneRecursive(NextNumber(i));
        }

        public int NextNumber(int i)
        {
            return i % 2 == 0 ? i / 2 : (3 * i) + 1;
        }

        public int StepsToCollatzNumberOneNonRecursive(int i)
        {
            var steps = 0;
            while (i > 1)
            {
                steps++;
                i = NextNumber(i);
            }
            return steps;
        }


        public IEnumerable<int> SequenceToCollatzNumberOne(int i)
        {
            var ints = new List<int>();

            ints.Add(i);
            while (i > 1)
            {
                i = NextNumber(i);
                ints.Add(i);
            }
            
            return ints;
        }
    }
}
