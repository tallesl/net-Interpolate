namespace InterpolateLibrary
{
    using System;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Scott Hanselman implementation.
    /// http://www.hanselman.com/blog/ASmarterOrPureEvilToStringWithExtensionMethods.aspx
    /// </summary>
    public static class HanselmanFormatter
    {
        public static string HanselmanFormat(this string format, object arguments)
        {
            StringBuilder sb = new StringBuilder();
            Type type = arguments.GetType();
            Regex reg = new Regex(@"({)([^}]+)(})", RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(format);
            int startIndex = 0;
            foreach (Match m in mc)
            {
                Group g = m.Groups[2]; //it's second in the match between { and }  
                int length = g.Index - startIndex - 1;
                sb.Append(format.Substring(startIndex, length));

                string toGet = String.Empty;
                string toFormat = String.Empty;
                int formatIndex = g.Value.IndexOf(":"); //formatting would be to the right of a :  
                if (formatIndex == -1) //no formatting, no worries  
                {
                    toGet = g.Value;
                }
                else //pickup the formatting  
                {
                    toGet = g.Value.Substring(0, formatIndex);
                    toFormat = g.Value.Substring(formatIndex + 1);
                }

                //first try properties  
                PropertyInfo retrievedProperty = type.GetProperty(toGet);
                Type retrievedType = null;
                object retrievedObject = null;
                if (retrievedProperty != null)
                {
                    retrievedType = retrievedProperty.PropertyType;
                    retrievedObject = retrievedProperty.GetValue(arguments, null);
                }
                else //try fields  
                {
                    FieldInfo retrievedField = type.GetField(toGet);
                    if (retrievedField != null)
                    {
                        retrievedType = retrievedField.FieldType;
                        retrievedObject = retrievedField.GetValue(arguments);
                    }
                }

                if (retrievedType != null) //Cool, we found something  
                {
                    string result = String.Empty;
                    if (toFormat == String.Empty) //no format info  
                    {
                        result = retrievedType.InvokeMember("ToString",
                            BindingFlags.Public | BindingFlags.NonPublic |
                            BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
                            , null, retrievedObject, null) as string;
                    }
                    else //format info  
                    {
                        result = retrievedType.InvokeMember("ToString",
                            BindingFlags.Public | BindingFlags.NonPublic |
                            BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
                            , null, retrievedObject, new object[] { toFormat }) as string;
                    }
                    sb.Append(result);
                }
                else //didn't find a property with that name, so be gracious and put it back  
                {
                    sb.Append("{");
                    sb.Append(g.Value);
                    sb.Append("}");
                }
                startIndex = g.Index + g.Length + 1;
            }
            if (startIndex < format.Length) //include the rest (end) of the string  
            {
                sb.Append(format.Substring(startIndex));
            }
            return sb.ToString();
        }
    }
}
