using System.Collections.Generic;

namespace BookService
{
    /// <summary>
    /// Interface for working with storage
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Loads this instance from storage to list.
        /// </summary>
        /// <returns>Book list</returns>
        List<Book> Load();

        /// <summary>
        /// Saves the specified list to storage.
        /// </summary>
        /// <param name="list">The list.</param>
        void Save(IEnumerable<Book> list);
    }
}
