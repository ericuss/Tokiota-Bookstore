namespace Bookstore.DataAccess.Context
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Bookstore.Entities;
    using Bookstore.DataAccess.Mappings;

    /// <summary>
    /// Context of bookstore
    /// </summary>
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {
        }

        /// <summary>
        /// Author "collection"
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Books "collection"
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Publisher "collection"
        /// </summary>
        public DbSet<Publisher> Publishers { get; set; }

        /// <summary>
        /// Serie "collection"
        /// </summary>
        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuthorMapping.Create().Map(modelBuilder);
            BookMapping.Create().Map(modelBuilder);
            PublisherMapping.Create().Map(modelBuilder);
            SerieMapping.Create().Map(modelBuilder);
        }
    }
}
