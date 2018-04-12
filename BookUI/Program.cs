using System;
using System.Configuration;
using BookService;

namespace BookUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new BookListStorage(ConfigurationManager.AppSettings["destinationFiePath"]);
            var service = new BookListService(new NLogger(nameof(BookListService)));
            Book book = new Book("978-0-7356-6745-7", "Troelsen", "For beginners", "Microsoft Press", 2010, 813, 9.99);

            service.LoadFromStorage(storage);
            //service.AddBook(book);
            Console.WriteLine(book.ToString("ATPY"));

            //service.AddBook(new Book("568-0-7546-6555-4", "Anton Pypkin", "C#", "Playboy", 2005, 666, 100));
            //service.AddBook(new Book("242-1-7766-3215-5", "Блинов", "Java SE", "Четыре четверти", 2013, 896, 3.5));

            Console.WriteLine(service.FindBookByTag(new TestPredicate("Блинов")).ToString("AT"));

            Console.ReadKey();

            service.SortBooksByTag(new TestComparer());

            service.SaveToStorage(storage);
        }
    }
}
