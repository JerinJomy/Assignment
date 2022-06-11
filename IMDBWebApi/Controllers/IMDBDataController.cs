using Microsoft.AspNetCore.Mvc;

namespace IMDBWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IMDBDataController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public string TestAction()
        {
            return "hello";
        }
    }
}
