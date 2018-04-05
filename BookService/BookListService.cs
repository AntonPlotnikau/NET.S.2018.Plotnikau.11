using System;
using System.Collections.Generic;

namespace BookService
{
    /// <summary>
    /// Service for working with storage
    /// </summary>
    public class BookListService
    {
        #region Private Fields
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The list
        /// </summary>
        private List<Book> list;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">
        /// list is null
        /// or
        /// logger is null
        /// </exception>
        public BookListService(List<Book> list, ILogger logger)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            this.list = new List<Book>(list);

            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">logger is null</exception>
        public BookListService(ILogger logger)
        {
            this.list = new List<Book>();

            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <exception cref="ArgumentNullException">book is null</exception>
        /// <exception cref="ArgumentException">This book already exists</exception>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                this.logger.Info(nameof(ArgumentNullException));
                this.logger.Error(nameof(book) + "is null");
                throw new ArgumentNullException(nameof(book));
            }

            if (this.list.Contains(book))
            {
                this.logger.Error("This book already exists");
                throw new ArgumentException();
            }

            this.list.Add(book);
        }

        /// <summary>
        /// Removes the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <exception cref="ArgumentNullException">book is null</exception>
        /// <exception cref="ArgumentException">Book does not exists!</exception>
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                this.logger.Info(nameof(ArgumentNullException));
                this.logger.Error(nameof(book) + "is null");
                throw new ArgumentNullException(nameof(book));
            }

            if (this.list.Contains(book) == false) 
            {
                this.logger.Error("Book does not exists!");
                throw new ArgumentException();
            }

            this.list.Remove(book);
        }

        /// <summary>
        /// Finds the book by tag.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>book that was found</returns>
        /// <exception cref="ArgumentNullException">predicate is null</exception>
        public Book FindBookByTag(IPredicate predicate)
        {
            if (predicate == null)
            {
                this.logger.Info(nameof(ArgumentNullException));
                this.logger.Error(nameof(predicate) + "is null");
                throw new ArgumentNullException(nameof(predicate));
            }

            foreach (Book item in this.list) 
            {
                if (predicate.IsMatch(item))
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Sorts the books by tag.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">comparer is null</exception>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (comparer == null)
            {
                this.logger.Info(nameof(ArgumentNullException));
                this.logger.Error(nameof(comparer) + "is null");
                throw new ArgumentNullException(nameof(comparer));
            }

            this.list.Sort(comparer);
        }

        /// <summary>
        /// Loads from storage.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <exception cref="ArgumentNullException">storage is null</exception>
        public void LoadFromStorage(IStorage storage)
        {
            if (storage == null)
            {
                this.logger.Info(nameof(ArgumentNullException));
                this.logger.Error(nameof(storage) + "is null");
                throw new ArgumentNullException(nameof(storage));
            }

            this.list = storage.Load();
        }

        /// <summary>
        /// Saves to storage.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <exception cref="ArgumentNullException">storage is null</exception>
        public void SaveToStorage(IStorage storage)
        {
            if (storage == null)
            {
                this.logger.Info(nameof(ArgumentNullException));
                this.logger.Error(nameof(storage) + "is null");
                throw new ArgumentNullException(nameof(storage));
            }

            storage.Save(this.list);
        }
        #endregion
    }
}
