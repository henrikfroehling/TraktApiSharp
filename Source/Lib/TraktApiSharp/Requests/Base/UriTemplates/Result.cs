namespace UriTemplates
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/Result.cs" />
    /// </summary>
    internal class Result
    {
        internal bool ErrorDetected { get; set; }
        internal List<string> ParameterNames { get; set; }
        private const string _UriReservedSymbols = ":/?#[]@!$&'()*+,;=";
        private const string _UriUnreservedSymbols = "-._~";

        private StringBuilder _Result = new StringBuilder();

        internal Result()
        {
            ParameterNames = new List<string>();
        }

        internal StringBuilder Append(char value) => _Result.Append(value);

        internal StringBuilder Append(string value) => _Result.Append(value);

        public override string ToString() => _Result.ToString();

        internal void AppendName(string variable, OperatorInfo op, bool valueIsEmpty)
        {
            _Result.Append(variable);

            if (valueIsEmpty)
                _Result.Append(op.IfEmpty);
            else
                _Result.Append("=");
        }

        internal void AppendList(OperatorInfo op, bool explode, string variable, IList list)
        {
            foreach (object item in list)
            {
                if (op.Named && explode)
                {
                    _Result.Append(variable);
                    _Result.Append("=");
                }

                AppendValue(item.ToString(), 0, op.AllowReserved);

                _Result.Append(explode ? op.Seperator : ',');
            }

            if (list.Count > 0)
                _Result.Remove(_Result.Length - 1, 1);
        }

        internal void AppendDictionary(OperatorInfo op, bool explode, IDictionary<string, string> dictionary)
        {
            foreach (string key in dictionary.Keys)
            {
                _Result.Append(Encode(key, op.AllowReserved));

                if (explode)
                    _Result.Append('=');
                else
                    _Result.Append(',');

                AppendValue(dictionary[key], 0, op.AllowReserved);

                if (explode)
                    _Result.Append(op.Seperator);
                else
                    _Result.Append(',');
            }

            if (dictionary.Count > 0)
                _Result.Remove(_Result.Length - 1, 1);
        }

        internal void AppendValue(string value, int prefixLength, bool allowReserved)
        {
            if (prefixLength != 0 && prefixLength < value.Length)
                value = value.Substring(0, prefixLength);

            _Result.Append(Encode(value, allowReserved));
        }

        private static string Encode(string p, bool allowReserved)
        {
            var result = new StringBuilder();

            foreach (char c in p)
            {
                if ((c >= 'A' && c <= 'z')   //Alpha
                    || (c >= '0' && c <= '9')  // Digit
                    || _UriUnreservedSymbols.IndexOf(c) != -1  // Unreserved symbols  - These should never be percent encoded
                    || (allowReserved && _UriReservedSymbols.IndexOf(c) != -1))  // Reserved symbols - should be included if requested (+)
                {
                    result.Append(c);
                }
                else
                {
                    var bytes = Encoding.UTF8.GetBytes(new[] { c });

                    foreach (var abyte in bytes)
                        result.Append(HexEscape(abyte));
                }
            }

            return result.ToString();
        }

        internal static string HexEscape(byte i)
        {
            var esc = new char[3];

            esc[0] = '%';
            esc[1] = HexDigits[((i & 240) >> 4)];
            esc[2] = HexDigits[(i & 15)];

            return new string(esc);
        }

        internal static string HexEscape(char c)
        {
            var esc = new char[3];

            esc[0] = '%';
            esc[1] = HexDigits[(((int)c & 240) >> 4)];
            esc[2] = HexDigits[((int)c & 15)];

            return new string(esc);
        }

        private static readonly char[] HexDigits =
            new char[] {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F'
            };
    }
}
