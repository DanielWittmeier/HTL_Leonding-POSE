/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: TextJustify UnitTests
 *--------------------------------------------------------------
 */

using FluentAssertions;

using Xunit;

using SVNummerTest;

namespace UnitTest
{
    public class SVNummerTests
    {
        [Theory]
        [InlineData("1230290204")]
        [InlineData("1231240225")]
        [InlineData("4328240225")]
        [InlineData("4320111111")]
        public void T01_TestOK(string text)
        {
            SVNummer.IsSvNumberValid(text).Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("xxxx010525")]
        [InlineData(" 1230290204 ")]
        [InlineData("1230290204 ")]
        [InlineData("123029020412302902041230290204")]
        [InlineData("1231290204")]
        [InlineData("_231290204")]
        [InlineData("a231290204")]
        [InlineData("2230290204")]
        [InlineData("1330290204")]
        [InlineData("1240290204")]
        [InlineData("1232290204")]
        [InlineData("1230390204")]
        [InlineData("1230280204")]
        [InlineData("1230291204")]
        [InlineData("1230290304")]
        [InlineData("1230290314")]
        [InlineData("1230290315")]
        public void T02_TestNotOK(string text)
        {
            SVNummer.IsSvNumberValid(text).Should().BeFalse();
        }
    }
}