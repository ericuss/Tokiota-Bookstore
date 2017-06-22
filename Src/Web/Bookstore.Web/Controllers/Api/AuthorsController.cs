namespace Bookstore.Web.Controllers.Api
{
    using Bookstore.Entities;
    using Bookstore.Infrastructure.Business;
    using Bookstore.Web.Core.Api;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class AuthorsController : CoreApiController<Author>
    {

        public AuthorsController(IBusinessCore<Author> service)
            : base(service)
        {
        }        
    }
}
