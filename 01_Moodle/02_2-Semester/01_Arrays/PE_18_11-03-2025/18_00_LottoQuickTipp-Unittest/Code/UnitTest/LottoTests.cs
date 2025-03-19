/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Lotto UnitTests
 *--------------------------------------------------------------
 */

using FluentAssertions;

using Xunit;

using Lotto;

namespace UnitTest
{
    using System.Linq;

    using Lotto = Lotto.Lotto;

    public class LottoTests
    {
        [Fact]
        public void T01_QuickTip()
        {
            // try 100 random tips
            for (int i = 0; i < 100; i++)
            {
                int[] tip = Lotto.QuickTip(45);

                tip.Length.Should().Be(6);
                tip.Distinct().ToArray().Length.Should().Be(6);
                tip.All(no => no >= 1 && no <= 45).Should().BeTrue();
                tip.Should().BeInAscendingOrder(no => no);
            }
        }

        [Fact]
        public void T02_QuickTipWith6()
        {
            int[] tip = Lotto.QuickTip(6);
            tip.Distinct().ToArray().Length.Should().Be(6);
            tip.All(no => no >= 1 && no <= 6).Should().BeTrue();
            tip.Should().BeInAscendingOrder(no => no);
        }

        [Fact]
        public void T03_QuickTipRandom()
        {
            int   TotalCount = 100000;
            int   MaxNo      = 49;
            int[] counts     = new int[MaxNo];

            for (int i = 0; i < TotalCount; i++)
            {
                int[] tip = Lotto.QuickTip(MaxNo);
                foreach (var t in tip)
                {
                    counts[t-1]++;
                }
            }

            foreach (var noCount in counts)
            {
                noCount.Should().BeGreaterThan(TotalCount / MaxNo * 95 / 100);
            }
        }

        [Fact]
        public void T04_QuickTipException()
        {
            Lotto.QuickTip(5).Should().BeNull();
        }

        [Fact]
        public void T04_TipToString()
        {
            int[] tip = [1, 2, 3, 4, 5, 6];

            Lotto.TipToString(tip).Should().Be("1,2,3,4,5,6");
        }
    }
}