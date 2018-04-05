using System;
using System.Globalization;
using BookService;

namespace Providers
{
    public class TestFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;

        public TestFormatProvider() : this(CultureInfo.CurrentCulture) { }

        public TestFormatProvider(IFormatProvider parent) => this.parent = parent;

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object argument, IFormatProvider prov)
        {
            if (argument.GetType() != typeof(Book))
            {
                try
                {
                    return HandleOtherFormats(format, argument);
                }
                catch (FormatException e)
                {
                    throw new FormatException($"The format of '{format}' is invalid.");
                }
            }

            Book book = (Book)argument;

            switch (format)
            {
                case "A":
                    return $"{book.AuthorName}";
                case "T":
                    return $"{book.Title}";
                default:
                    try
                    {
                        return HandleOtherFormats(format, argument);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException($"The format of '{format}' is invalid.");
                    }
            }
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
