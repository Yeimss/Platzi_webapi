using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        public readonly IHelloWorldService _helloWorldService;
        public readonly ILogger<HelloWorldController> _logger;
        public readonly TareasContext dbcontext;
        public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger, TareasContext dbcontext)
        {
            _helloWorldService = helloWorldService;
            _logger = logger;
            this.dbcontext = dbcontext;
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
        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            dbcontext.Database.EnsureCreated();

            return Ok();
        }
    }
}
