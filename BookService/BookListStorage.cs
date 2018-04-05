using System;
using System.Collections.Generic;
using System.IO;

namespace BookService
{
    /// <summary>
    /// Class for work with binary file storage
    /// </summary>
    /// <seealso cref="BookService.IStorage" />
    public class BookListStorage : IStorage
    {
        #region Private Fields
        /// <summary>
        /// The destination path
        /// </summary>
        private readonly string destinationPath;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BookListStorage"/> class.
        /// </summary>
        /// <param name="destinationPath">The destination path.</param>
        /// <exception cref="ArgumentNullException">destination path is null</exception>
        public BookListStorage(string destinationPath)
        {
            this.destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads data from file to list.
        /// </summary>
        /// <returns>book list</returns>
        public List<Book> Load()
        {
            List<Book> list = new List<Book>();
            using (var fileStream = new FileStream(this.destinationPath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(fileStream))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length) 
                    {
                        list.Add(this.ReadBook(reader));
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Saves the specified list to binary file.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <exception cref="ArgumentNullException">list is null</exception>
        public void Save(List<Book> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            using (var fileStream = new FileStream(this.destinationPath, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new BinaryWriter(fileStream))
                {
                    foreach (Book item in list) 
                    {
                        this.WriteBook(writer, item);
                    }
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Reads the book.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Book object from binary file</returns>
        private Book ReadBook(BinaryReader reader)
        {
            string isbn = reader.ReadString();
            string authorName = reader.ReadString();
            string title = reader.ReadString();
            string publisher = reader.ReadString();
            int year = reader.ReadInt32();
            int numberOfPages = reader.ReadInt32();
            double price = reader.ReadDouble();
            Book book = new Book(isbn, authorName, title, publisher, year, numberOfPages, price);
            return book;
        }

        /// <summary>
        /// Writes the book to the binary file.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="book">The book.</param>
        private void WriteBook(BinaryWriter writer, Book book)
        {
            writer.Write(book.ISBN);
            writer.Write(book.AuthorName);
            writer.Write(book.Title);
            writer.Write(book.Publisher);
            writer.Write(book.Year);
            writer.Write(book.NumberOfPages);
            writer.Write(book.Price);
        }
        #endregion
    }
}
