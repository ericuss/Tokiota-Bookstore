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
            services.AddDbContext<BookstoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
           // services.AddSingleton<IDBInitialize, DBInitialize>();
        }
    }
}
