using StringLib;
using Xunit;

namespace UnitTests
{
    public class FormatExpressionTests
    {
        [Fact]
        public void Format_WithExpressionReturningNull_DoesNotThrowException()
        {
            //arrange
            var expr = new FormatExpression("{foo}");

            //assert
            Assert.Equal(string.Empty, expr.Eval(new {foo = (object)null}));
        }

        [Fact]
        public void Format_WithoutColon_ReadsWholeExpression() { 
            //arrange
            var expr = new FormatExpression("{foo}");

            //assert
            Assert.Equal("foo", expr.Expression);
        }

        [Fact]
        public void Format_WithColon_ParsesoutFormat    ()
        {
            //arrange
            var expr = new FormatExpression("{foo:#.##}");

            //assert
            Assert.Equal("#.##", expr.Format);
        }

        [Fact]
        public void Eval_WithNamedExpression_EvalsPropertyOfExpression() {
            //arrange
            var expr = new FormatExpression("{foo}");

            //act
            string result = expr.Eval(new { foo = 123 });
            
            //assert
            Assert.Equal("123", result);
        }

        [Fact]
        public void Eval_WithNamedExpressionAndFormat_EvalsPropertyOfExpression()
        {
            //arrange
            var expr = new FormatExpression("{foo:#.##}");

            //act
            string result = expr.Eval(new { foo = 1.23456 });

            //assert
            Assert.Equal("1.23", result);
        }
    }
}
