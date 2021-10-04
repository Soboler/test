using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Interview
{
    // Если тесты не запускаются через Test Explorer, выполните Clean Solution
    public class Tests
    {
        public static IEnumerable<object[]> TestCases()
        {
            yield return new object[] {"Zero", "Zero", 0};
            yield return new object[] {"One", "Zero", 1};
            yield return new object[] {"Zero", "One", -1};
            yield return new object[] {"One", "Two", -1};
            yield return new object[] {"One", "One", 0};
            yield return new object[] {"OneTwo", "TwoOne", -1};
            yield return new object[] {"OneZero", "One", 1};
            yield return new object[] {"OneEight", "Nine", 1};
            yield return new object[] {"OneNine", "TwoEight", -1};
            yield return new object[] {"SixNine", "TwoNine", 1};
            yield return new object[] {"FiveSixOne", "SixFourOne", -1};
            yield return new object[] {"OneZero", "OneOne", -1};
            yield return new object[] {"ThreeTwo", "Four", 1};
            yield return new object[] {"OneZeroSeven", "OneZeroSix", 1};
            yield return new object[] {"Eight", "Nine", -1};
            yield return new object[] {"Four", "Five", -1};
            yield return new object[] {"Eight", "Seven", 1};
            yield return new object[] {"OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero", "OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero", -1};
            yield return new object[] {"OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZero", "OneZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroZeroOne", -1};
            yield return new object[] {"OneThreeTwoFourNineZeroSixFiveEightNine", "OneFourThreeTwoNineZeroSixFiveEightNine", -1};
            yield return new object[] {"ThreeThreeThree", "TwoTwoTwo", 1};
            yield return new object[] {"OneThreeTwoFourNineZeroSixFiveEightNine", "OneThreeTwoFourNineZeroSixFiveEightNine", 0};
            yield return new object[] {"NineOneThreeTwoFourNineSixFiveEight", "OneThreeTwoFourNineZeroSixFiveEightNine", -1};
            yield return new object[] {"OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOne", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", -1};
            yield return new object[] {"OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneTwo", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoOne", -1};
            yield return new object[] {"OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOne", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", 1};
            yield return new object[] {"OneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneOneThree", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoZero", 1};
            yield return new object[] {"TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", "ThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThree", 1};
            yield return new object[] {"ThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThreeThree", "TwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwoTwo", -1};
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test(string first, string second, int expected)
        {
            var actual = new NumberStringsComparer().Compare(first, second);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> TestCasesBig()
        {
            yield return new object[] {0, 1, -1};
            yield return new object[] {5, 4, 1};
            yield return new object[] {7, 7, 0};
        }

        [TestCaseSource(nameof(TestCasesBig)), Timeout(1000)]
        public void TestBig1(int lastDigit1, int lastDigit2, int expected)
        {
            int len = 200000;
            var builder = new StringBuilder(5 * len);
            for (int i = 0; i < len; i++)
                builder.Append(digits[(i + 1) % 10]);
            var s = builder.ToString();
            var first = s + digits[lastDigit1];
            var second = s + digits[lastDigit2];
            var actual = new NumberStringsComparer().Compare(first, second);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(TestCasesBig)), Timeout(1000)]
        public void TestBig2(int lastDigit1, int lastDigit2, int expected)
        {
            int len = 200000;
            var builder = new StringBuilder(5 * len);
            for (int i = 0; i < len; i++)
                builder.Append(digits[9]);
            var s = builder.ToString();
            var first = s + digits[lastDigit1];
            var second = s + digits[lastDigit2];
            var actual = new NumberStringsComparer().Compare(first, second);
            Assert.AreEqual(expected, actual);
        }

        [Test, Timeout(1000)]
        public void TestBig3()
        {
            int len = 200000;
            var builder = new StringBuilder(5 * len);
            for (int i = 0; i < len; i++)
                builder.Append(digits[0]);
            var s = builder.ToString();
            var first = digits[3] + s;
            var second = digits[5];
            var actual = new NumberStringsComparer().Compare(first, second);
            Assert.AreEqual(1, actual);
        }

        private static readonly string[] digits =
        {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
        };
    }
}
