namespace Bookstore.Entities
{
    using Bookstore.Entities.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Serie entity
    /// </summary>
    public class Serie : EntityCore
    {
        /// <summary>
        /// Name of serie
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Books
        /// </summary>
        public List<Book> Books { get; set; }
    }
}
