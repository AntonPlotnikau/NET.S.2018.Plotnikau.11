namespace BookService
{
    /// <summary>
    /// Interface for logging
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(string message);

        /// <summary>
        /// Inform message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(string message);

        /// <summary>
        /// Warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warn(string message);

        /// <summary>
        /// Error message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);

        /// <summary>
        /// Fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Fatal(string message);
    }
}
