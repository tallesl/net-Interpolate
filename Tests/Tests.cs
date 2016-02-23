namespace InterpolateLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Globalization;
    using System.Threading;

    [TestClass]
    public class Tests
    {
        static string Format(string format, object o)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Change the comments bellow to check how the method performs:

            return format.HaackFormat(o);
            //return format.HanselmanFormat(o);
            //return format.HenriFormat(o);
            //return format.JamesFormat(o);
            //return format.OskarFormat(o);
        }

        [TestMethod]
        public void StringFormat_WithMultipleExpressions_FormatsThemAll()
        {
            //arrange
            var o = new { foo = 123.45, bar = 42, baz = "hello" };

            //act
            string result = Format("{foo} {foo} {bar}{baz}", o);

            //assert
            Assert.AreEqual("123.45 123.45 42hello", result);
        }

        [TestMethod]
        public void StringFormat_WithDoubleEscapedCurlyBraces_DoesNotFormatString()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act
            string result = Format("{{{{foo}}}}", o);

            //assert
            Assert.AreEqual("{{foo}}", result);
        }

        [TestMethod]
        public void StringFormat_WithFormatSurroundedByDoubleEscapedBraces_FormatsString()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act
            string result = Format("{{{{{foo}}}}}", o);

            //assert
            Assert.AreEqual("{{123.45}}", result);
        }

        [TestMethod]
        public void Format_WithEscapeSequence_EscapesInnerCurlyBraces()
        {
            var o = new { foo = 123.45 };

            //act
            string result = Format("{{{foo}}}", o);

            //assert
            Assert.AreEqual("{123.45}", result);
        }

        [TestMethod]
        public void Format_WithEmptyString_ReturnsEmptyString()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act
            string result = Format(string.Empty, o);

            //assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Format_WithNoFormats_ReturnsFormatStringAsIs()
        {
            var o = new { foo = 123.45 };

            //act
            string result = Format("a b c", o);

            //assert
            Assert.AreEqual("a b c", result);
        }

        [TestMethod]
        public void Format_WithFormatType_ReturnsFormattedExpression()
        {
            var o = new { foo = 123.45 };

            //act
            string result = Format("{foo:#.#}", o);

            //assert
            Assert.AreEqual("123.5", result);
        }

        [TestMethod]
        public void Format_WithSubProperty_ReturnsValueOfSubProperty()
        {
            //arrange
            var o = new { foo = new { bar = 123.45 } };

            //act
            string result = Format("{foo.bar:#.#}ms", o);

            //assert
            Assert.AreEqual("123.5ms", result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Format_WithFormatNameNotInObject_ThrowsFormatException()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act, assert
            Format("{bar}", o);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Format_WithNoEndFormatBrace_ThrowsFormatException()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act
            Format("{bar", o);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Format_WithEscapedEndFormatBrace_ThrowsFormatException()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act
            Format("{foo}}", o);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Format_WithDoubleEscapedEndFormatBrace_ThrowsFormatException()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act
            Format("{foo}}}}bar", o);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Format_WithDoubleEscapedEndFormatBraceWhichTerminatesString_ThrowsFormatException()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act
            Format("{foo}}}}", o);
        }

        [TestMethod]
        public void Format_WithEndBraceFollowedByEscapedEndFormatBraceWhichTerminatesString_FormatsCorrectly()
        {
            var o = new { foo = 123.45 };

            //act
            string result = Format("{foo}}}", o);

            //assert
            Assert.AreEqual("123.45}", result);
        }

        [TestMethod]
        public void Format_WithEndBraceFollowedByEscapedEndFormatBrace_FormatsCorrectly()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act
            string result = Format("{foo}}}bar", o);

            //assert
            Assert.AreEqual("123.45}bar", result);
        }

        [TestMethod]
        public void Format_WithEndBraceFollowedByDoubleEscapedEndFormatBrace_FormatsCorrectly()
        {
            //arrange
            var o = new { foo = 123.45 };

            //act
            string result = Format("{foo}}}}}bar", o);

            //assert
            Assert.AreEqual("123.45}}bar", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Format_WithNullFormatString_ThrowsArgumentNullException()
        {
            //act
            Format(null, 123);
        }
    }
}
