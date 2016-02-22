namespace InterpolateLibrary.Haack
{
    internal class LiteralFormat : ITextExpression
    {
        internal LiteralFormat(string literalText)
        {
            LiteralText = literalText;
        }

        private string LiteralText { get; set; }

        public string Eval(object o)
        {
            string literalText = LiteralText
                .Replace("{{", "{")
                .Replace("}}", "}");
            return literalText;
        }
    }
}
