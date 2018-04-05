using System.Globalization;
using BookService;
using NUnit.Framework;
using Providers;


namespace Books.Tests
{
    [TestFixture]
    public class ToStringTests
    {
        [Test]
        [TestCase("AT", ExpectedResult = "Jeffrey Richter, CLR via C#")]
        [TestCase("ATPY", ExpectedResult = "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012")]
        [TestCase("IATPYN", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826.")]
        [TestCase("G", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826., 59,99$")]
        public string ToStringFormatTests(string format)
        {
            Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            return book.ToString(format);
        }

        [TestCase("A", ExpectedResult = "Jeffrey Richter")]
        [TestCase("T", ExpectedResult = "CLR via C#")]
        public string ProviderToStringTests(string format)
        {
            Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            TestFormatProvider provider = new TestFormatProvider();
            return provider.Format(format, book, CultureInfo.CurrentCulture);
        }
    }
}
