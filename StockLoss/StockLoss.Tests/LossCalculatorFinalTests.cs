namespace StockLoss.Tests
{
    using System;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains the final tests for the <see cref="LossCalculator.CalculateMaxLoss(int[])"/>.
    /// If these pasts pass, the task can be considered done.
    /// </summary>
    [TestClass]
    public class LossCalculatorFinalTests
    {
        private readonly LossCalculator subject = new LossCalculator();

        [TestMethod]
        public void Throws_For_Null()
        {
            Action act = () => subject.CalculateMaxLoss(null);

            act.ShouldThrow<ArgumentNullException>().Which.ParamName.Should().Be("values");
        }

        [TestMethod]
        public void Throws_For_Empty()
        {
            Action act = () => subject.CalculateMaxLoss(new int[] { });

            act.ShouldThrow<ArgumentException>().Which.ParamName.Should().Be("values");
        }

        [TestMethod]
        public void Zero_For_SimpleInputWithOneValue()
        {
            var values = new int[] { 3 };

            var result = subject.CalculateMaxLoss(values);

            result.ShouldBeEquivalentTo(0);
        }

        [TestMethod]
        public void Zero_For_SimpleInputWithoutLoss()
        {
            var values = new int[] { 1, 2 };

            var result = subject.CalculateMaxLoss(values);

            result.ShouldBeEquivalentTo(0);
        }

        [TestMethod]
        public void Loss_For_SimpleInputWithLoss()
        {
            var values = new int[] { 2, 1 };

            var result = subject.CalculateMaxLoss(values);

            result.ShouldBeEquivalentTo(1);

        }

        [TestMethod]
        public void Loss_For_InputWhereMaxIsAfterLoss()
        {
            var values = new int[] {2, 1, 3};

            var result = subject.CalculateMaxLoss(values);

            result.ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void Loss_For_InputWhereLossIsAfterMax()
        {
            var values = new int[] { 1, 3, 2 };

            var result = subject.CalculateMaxLoss(values);

            result.ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void Loss_For_DecreasingInput()
        {
            var values = new int[] { 3, 2, 1 };

            var result = subject.CalculateMaxLoss(values);

            result.ShouldBeEquivalentTo(2);
        }

        [TestMethod]
        public void Loss_For_DecreasingZigZag()
        {
            var values = new int[] { 8, 5, 6, 3 };

            var result = subject.CalculateMaxLoss(values);

            result.ShouldBeEquivalentTo(5);
        }

        [TestMethod]
        public void Loss_For_ZigZag()
        {
            var values = new int[] { 1, 8, 5, 6, 4, 9, 7, 6, 7, 4 };

            var result = subject.CalculateMaxLoss(values);

            result.ShouldBeEquivalentTo(5);
        }

        [TestMethod]
        public void Loss_For_ZigZag_V2()
        {
            var values = new int[] { 1, 8, 5, 6, 4, 9, 10, 11 };

            var result = subject.CalculateMaxLoss(values);

            result.ShouldBeEquivalentTo(4);
        }
    }
}
