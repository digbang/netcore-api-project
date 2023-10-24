using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    public class PingController : BaseController
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Respond(Ok(new
            {
                message = "Pong!",
            }));
        }
    }
}
