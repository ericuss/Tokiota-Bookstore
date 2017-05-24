
namespace Bookstore.Entities
{
    using Bookstore.Entities.Core;
    using System;

    /// <summary>
    /// Book entity
    /// </summary>
    public class Book : EntityCore
    {
        /// <summary>
        /// Name of book
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Decription of book
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Year when book is published
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Author id
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Serie id
        /// </summary>
        public Guid? SerieId { get; set; }

        /// <summary>
        /// Serie
        /// </summary>
        public Serie Serie { get; set; }

        /// <summary>
        /// Publisher id
        /// </summary>
        public Guid PublisherId { get; set; }

        /// <summary>
        /// Publisher
        /// </summary>
        public Publisher Publisher { get; set; }
    }
}
