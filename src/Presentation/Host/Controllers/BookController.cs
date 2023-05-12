using TaghcheCC.ApplicationCore.QueryService;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookQueryService _bookQS;

        public BookController(IBookQueryService bookQS)
        {
            _bookQS = bookQS;
        }
        [HttpGet]
        public async Task<IActionResult> GetBookById(string id)
        {
            return Ok(await _bookQS.GetBook(id));
        }
    }
}
