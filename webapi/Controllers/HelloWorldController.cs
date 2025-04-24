using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        public readonly IHelloWorldService _helloWorldService;
        public readonly ILogger<HelloWorldController> _logger;
        public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger)
        {
            _helloWorldService = helloWorldService;
            _logger = logger;
        }
        [HttpGet]
        [Route("HelloWorld")]
        public async Task<IActionResult> HelloWorld()
        {
            try
            {
                _logger.LogInformation("Log por consola de prueba");
                //int z = 8 / 0;
                return Ok(new
                {
                    message = _helloWorldService.GetHelloWorld()
                });
            }
            catch (Exception)
            {
                _logger.LogWarning("Errrrrroooooorrrrrrrr");
                return BadRequest(new
                {
                    message = "Error inesperado"
                });
            }
        }
    }
}
