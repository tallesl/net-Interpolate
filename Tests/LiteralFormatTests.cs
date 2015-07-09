namespace NamedFormat.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LiteralFormatTests
    {
        [TestMethod]
        public void Literal_WithEscapedCloseBraces_CollapsesDoubleBraces()
        {
            //arrange
            var literal = new LiteralFormat("hello}}world");

            //act
            string result = literal.Eval(null);

            //assert
            Assert.AreEqual("hello}world", result);
        }

        [TestMethod]
        public void Literal_WithEscapedOpenBraces_CollapsesDoubleBraces()
        {
            //arrange
            var literal = new LiteralFormat("hello{{world");

            //act
            string result = literal.Eval(null);

            //assert
            Assert.AreEqual("hello{world", result);
        }
    }
}
