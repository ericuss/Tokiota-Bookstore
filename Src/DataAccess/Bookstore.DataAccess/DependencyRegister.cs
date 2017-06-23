namespace Bookstore.DataAccess
{
    using Bookstore.DataAccess.Context;
    using Bookstore.Infrastructure.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Register dependencies
    /// </summary> 
    public static class DependencyRegister
    {
        /// <summary>
        /// Register function
        /// </summary>
        /// <param name="services">service collection</param>
        public static void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            var conn = string.IsNullOrWhiteSpace(configuration.GetConnectionString("DefaultConnection"))
                            ? configuration.GetSection("DefaultConnection").Value
                            : configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BookstoreContext>(options => options.UseSqlServer(conn));
            services.AddScoped<IDBInitialize, DBInitialize>();
        }
    }
}
