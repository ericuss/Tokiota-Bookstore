namespace Bookstore.Web.Controllers.Api
{
    using Bookstore.Entities;
    using Bookstore.Infrastructure.Business;
    using Bookstore.Web.Core.Api;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class BooksController : CoreApiController<Book>
    {

        public BooksController(IBusinessCore<Book> service)
            : base(service)
        {
        }        
    }
}
