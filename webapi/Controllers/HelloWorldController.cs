using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        public readonly IHelloWorldService _helloWorldService;
        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }
        [HttpGet]
        [Route("HelloWorld")]
        public async Task<IActionResult> HelloWorld()
        {
            return Ok(new
            {
                message = _helloWorldService.GetHelloWorld()
            });
        }
    }
}
