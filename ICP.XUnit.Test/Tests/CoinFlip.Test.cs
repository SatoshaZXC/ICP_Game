using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICP;

namespace ICP.XUnit.Test.Tests
{
    public class CoinFlipTests
    {
        // Parameterized test for EvaluateResult method
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        public void EvaluateResult_ShouldReturnCorrectValue(
           bool playerChoice,
           bool coinResult,
           bool expected)
        {
            bool result =
                CoinFlip.EvaluateResult(playerChoice, coinResult);

            Assert.Equal(expected, result);
        }
        // This test is skipped because the coin animation is not testable in a unit test environment
        [Fact(Skip = "Coin animation is not testable yet")]
        public void CoinAnimation_ShouldWork()
        {
        }
        // This test is expected to fail because the cursed luck system is not implemented yet
        [Fact]
        public void XFail_CursedLuck_ShouldAlwaysLose()
        {
            // TODO: implement cursed luck system
            bool result =
                CoinFlip.EvaluateResult(true, true);

            Assert.False(result);
        }

    }
}
