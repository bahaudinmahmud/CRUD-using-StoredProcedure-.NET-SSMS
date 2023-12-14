using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrollMarket.Presentation.Web.APIModels;
using TrollMarket.Presentation.Web.APIServices;

namespace TrollMarket.Presentation.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIShipperController : ControllerBase
    {
        private readonly APIShipperService _service;
        public APIShipperController(APIShipperService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult Insert(ShipperUpsertDto vm)
        {
            _service.Insert(vm);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var dto = _service.GetShipperById(id);
            return Ok(dto);
        }
        [HttpPut]
        public IActionResult Update(ShipperUpsertDto vm)
        {

            _service.Update(vm);
            return Ok();
        }
    }
}
