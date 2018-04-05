namespace BookService
{
    /// <summary>
    /// interface for match checking
    /// </summary>
    public interface IPredicate
    {
        /// <summary>
        /// Determines whether the specified source is match tag.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <c>true</c> if the specified source is match; otherwise, <c>false</c>.
        /// </returns>
        bool IsMatch(Book source);
    }
}
