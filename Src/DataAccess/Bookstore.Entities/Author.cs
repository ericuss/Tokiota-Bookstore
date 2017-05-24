
namespace Bookstore.Entities
{
    using Bookstore.Entities.Core;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Author entity
    /// </summary>
    public class Author : EntityCore
    {
        /// <summary>
        /// Name of author
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Last name of author
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Born
        /// </summary>
        public int Born { get; set; }

        /// <summary>
        /// Books
        /// </summary>
        public List<Book> Books { get; set; }
    }
}
