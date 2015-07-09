using StringLib;
using Xunit;

namespace UnitTests
{
    public class LiteralFormatTests
    {
        [Fact]
        public void Literal_WithEscapedCloseBraces_CollapsesDoubleBraces() { 
            //arrange
            var literal = new LiteralFormat("hello}}world");
            //act
            string result = literal.Eval(null);
            //assert
            Assert.Equal("hello}world", result);
        }

        [Fact]
        public void Literal_WithEscapedOpenBraces_CollapsesDoubleBraces()
        {
            //arrange
            var literal = new LiteralFormat("hello{{world");
            //act
            string result = literal.Eval(null);
            //assert
            Assert.Equal("hello{world", result);
        }
    }
}
