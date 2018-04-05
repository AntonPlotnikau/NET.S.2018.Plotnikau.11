using System;
using NLog;

namespace BookService
{
    /// <summary>
    /// Logger that use NLog framework
    /// </summary>
    /// <seealso cref="BookService.ILogger" />
    public class NLogger : ILogger
    {
        #region Private Fields
        /// <summary>
        /// The logger
        /// </summary>
        private readonly Logger logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NLogger"/> class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <exception cref="ArgumentNullException">className is null</exception>
        public NLogger(string className)
        {
            if (className == null)
            {
                throw new ArgumentNullException(nameof(className));
            }

            this.logger = LogManager.GetLogger(className);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public void Debug(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            this.logger.Debug(message);
        }

        /// <summary>
        /// Error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public void Error(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            this.logger.Error(message);
        }

        /// <summary>
        /// Fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public void Fatal(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            this.logger.Fatal(message);
        }

        /// <summary>
        /// Inform message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public void Info(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            this.logger.Info(message);
        }

        /// <summary>
        /// Warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">message is null</exception>
        public void Warn(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            this.logger.Warn(message);
        }
        #endregion
    }
}
