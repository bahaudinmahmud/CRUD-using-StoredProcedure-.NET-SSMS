using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrollMarket.Presentation.Web.APIServices;

namespace TrollMarket.Presentation.Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIMerchandiseController : ControllerBase
    {
        private readonly APIMerchandiseService merchandiseService;
        public APIMerchandiseController(APIMerchandiseService merchandiseService)
        {
            this.merchandiseService = merchandiseService;
        }
        [HttpGet]
        public ActionResult GetDetail(int Id)
        {
            var dto = merchandiseService.GetDetail(Id);
            return  Ok(dto);
        }
    }
}
