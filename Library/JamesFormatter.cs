namespace NamedFormat
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;

    /// <summary>
    /// James Newton-King implementation tweaked by Ativ Aziz.
    /// http://james.newtonking.com/archive/2008/03/29/formatwith-2-0-string-formatting-with-named-variables
    /// http://haacked.com/archive/2009/01/14/named-formats-redux.aspx
    /// </summary>
    public static class JamesFormatter
    {
        public static string JamesFormat(this string format, object arguments)
        {
            if (format == null)
                throw new ArgumentNullException("format");

            List<object> values = new List<object>();
            string rewrittenFormat = Regex.Replace(format,
                @"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+",
                delegate(Match m)
                {
                    Group startGroup = m.Groups["start"];
                    Group propertyGroup = m.Groups["property"];
                    Group formatGroup = m.Groups["format"];
                    Group endGroup = m.Groups["end"];

                    values.Add((propertyGroup.Value == "0")
                      ? arguments
                      : Eval(arguments, propertyGroup.Value));

                    int openings = startGroup.Captures.Count;
                    int closings = endGroup.Captures.Count;

                    return openings > closings || openings % 2 == 0
                         ? m.Value
                         : new string('{', openings) + (values.Count - 1) + formatGroup.Value
                           + new string('}', closings);
                },
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            return string.Format(rewrittenFormat, values.ToArray());
        }

        private static object Eval(object source, string expression)
        {
            try
            {
                return DataBinder.Eval(source, expression);
            }
            catch (HttpException e)
            {
                throw new FormatException(null, e);
            }
        }
    }
}