using System;
using System.Globalization;

namespace BookService
{
    /// <summary>
    /// Class that represents book entity
    /// </summary>
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="System.IComparable{BookService.Book}" />
    /// <seealso cref="System.IEquatable{BookService.Book}" />
    /// <seealso cref="System.IFormattable" />
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>, IFormattable
    {
        #region Private Fields
        /// <summary>
        /// The unique identifier of the book
        /// </summary>
        private string isbn;

        /// <summary>
        /// The author name
        /// </summary>
        private string authorName;

        /// <summary>
        /// The title
        /// </summary>
        private string title;

        /// <summary>
        /// The publisher
        /// </summary>
        private string publisher;

        /// <summary>
        /// The year
        /// </summary>
        private int year;

        /// <summary>
        /// The number of pages
        /// </summary>
        private int numberOfPages;

        /// <summary>
        /// The price
        /// </summary>
        private double price;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">The unique identifier of the book</param>
        /// <param name="authorName">Name of the author.</param>
        /// <param name="title">The title.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="year">The year.</param>
        /// <param name="numberOfPages">The number of pages.</param>
        /// <param name="price">The price.</param>
        public Book(string isbn, string authorName, string title, string publisher, int year, int numberOfPages, double price)
        {
            this.ISBN = isbn;
            this.AuthorName = authorName;
            this.Title = title;
            this.Publisher = publisher;
            this.Year = year;
            this.NumberOfPages = numberOfPages;
            this.Price = price;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier of the book.
        /// </summary>
        /// <value>
        /// The unique identifier of the book.
        /// </value>
        /// <exception cref="ArgumentException">The unique identifier of the book is null or white space</exception>
        public string ISBN
        {
            get => this.isbn;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.isbn));
                }

                this.isbn = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        /// <value>
        /// The name of the author.
        /// </value>
        /// <exception cref="ArgumentException">authorName is null or white space</exception>
        public string AuthorName
        {
            get => this.authorName;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.authorName));
                }

                this.authorName = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        /// <exception cref="ArgumentException">title is null or white space</exception>
        public string Title
        {
            get => this.title;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.title));
                }

                this.title = value;
            }
        }

        /// <summary>
        /// Gets or sets the publisher.
        /// </summary>
        /// <value>
        /// The publisher.
        /// </value>
        /// <exception cref="ArgumentException">publisher is null or white space</exception>
        public string Publisher
        {
            get => this.publisher;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.publisher));
                }

                this.publisher = value;
            }
        }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        /// <exception cref="ArgumentException">year is less than zero or more than current year</exception>
        public int Year
        {
            get => this.year;

            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException(nameof(this.year));
                }

                this.year = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>
        /// The number of pages.
        /// </value>
        /// <exception cref="ArgumentException">number of pages is less than one</exception>
        public int NumberOfPages
        {
            get => this.numberOfPages;

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(nameof(this.numberOfPages));
                }

                this.numberOfPages = value;
            }
        }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        /// <exception cref="ArgumentException">price is less than or equal to zero</exception>
        public double Price
        {
            get => this.price;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(this.price));
                }

                this.price = value;
            }
        }

        #endregion

        #region IComparable realization

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentNullException">other is null</exception>
        public int CompareTo(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (string.Compare(this.AuthorName, other.AuthorName, true) == 0 && string.Compare(this.Title, other.Title, true) == 0) 
            {
                return 0;
            }

            if (string.Compare(this.AuthorName, other.AuthorName, true) > 0)
            {
                return 1;
            }

            if (string.Compare(this.Title, other.Title, true) > 0)
            {
                return 1;
            }

            return -1;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        /// <exception cref="ArgumentException">object is null</exception>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            if (ReferenceEquals(obj, null)) 
            {
                return -1;
            }

            if (this.GetType() == obj.GetType())
            {
                return this.CompareTo((Book)obj);
            }

            throw new ArgumentException(nameof(obj));
        }

        #endregion

        #region Equality realization

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj.GetType() == this.GetType())
            {
                return this.Equals((Book)obj);
            }

            return false;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (this.AuthorName == other.AuthorName && this.Title == other.Title)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region String format realization

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format of the string.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format of the string.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException">format is invalid</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return $"ISBN 13: {ISBN}, {AuthorName}, {Title}, \"{Publisher}\", {Year}, P. {NumberOfPages}., {Price}$";
                case "AT":
                    return $"{AuthorName}, {Title}";
                case "ATPY":
                    return $"{AuthorName}, {Title}, \"{Publisher}\", {Year}";
                case "IATPYN":
                    return $"ISBN 13: {ISBN}, {AuthorName}, {Title}, \"{Publisher}\", {Year}, P. {NumberOfPages}.";
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        #endregion

        #region GetHashCode overriding
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.ISBN.GetHashCode();
        }
        #endregion
    }
}
