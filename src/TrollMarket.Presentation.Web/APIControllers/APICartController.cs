using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrollMarket.Presentation.Web.APIModels;
using TrollMarket.Presentation.Web.APIServices;

namespace TrollMarket.Presentation.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APICartController : ControllerBase
    {
        private readonly APICartService _service;
        public APICartController(APICartService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Insert(CartDto dto)
        {
            _service.Insert(dto);
            return Ok();
        }

    }
}
