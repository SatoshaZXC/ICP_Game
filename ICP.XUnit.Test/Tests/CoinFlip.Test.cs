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
        [Fact(Skip = "Coin animation is not testable yet")]
        public void CoinAnimation_ShouldWork()
        {
        }
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
