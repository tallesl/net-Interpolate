namespace NamedFormat.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FormatExpressionTests
    {
        [TestMethod]
        public void Format_WithExpressionReturningNull_DoesNotThrowException()
        {
            //arrange
            var expr = new FormatExpression("{foo}");

            //assert
            Assert.AreEqual(string.Empty, expr.Eval(new { foo = (object)null }));
        }

        [TestMethod]
        public void Format_WithoutColon_ReadsWholeExpression()
        {
            //arrange
            var expr = new FormatExpression("{foo}");

            //assert
            Assert.AreEqual("foo", expr.Expression);
        }

        [TestMethod]
        public void Format_WithColon_ParsesoutFormat()
        {
            //arrange
            var expr = new FormatExpression("{foo:#.##}");

            //assert
            Assert.AreEqual("#.##", expr.Format);
        }

        [TestMethod]
        public void Eval_WithNamedExpression_EvalsPropertyOfExpression()
        {
            //arrange
            var expr = new FormatExpression("{foo}");

            //act
            string result = expr.Eval(new { foo = 123 });

            //assert
            Assert.AreEqual("123", result);
        }

        [TestMethod]
        public void Eval_WithNamedExpressionAndFormat_EvalsPropertyOfExpression()
        {
            //arrange
            var expr = new FormatExpression("{foo:#.##}");

            //act
            string result = expr.Eval(new { foo = 1.23456 });

            //assert
            Assert.AreEqual("1.23", result);
        }
    }
}
