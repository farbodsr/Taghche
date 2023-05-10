using ApplicationCore.QueryService;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookQueryService _bookQS;

        public BookController(BookQueryService bookQS)
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
