using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TrollMarket.Presentation.Web.APIModels;
using TrollMarket.Presentation.Web.APIServices;
using TrollMarket.Presentation.Web.Services;

namespace TrollMarket.Presentation.Web.APIControllers
{
    [Authorize(Roles = "buyer")]
    [Route("api/[controller]")]
    [ApiController]
    public class APIBalanceController : ControllerBase
    {
        private readonly APIBalanceService balanceService;
        public APIBalanceController(APIBalanceService balanceService)
        {
            this.balanceService = balanceService;
        }
        [HttpPatch]
        public IActionResult TopUp(BalanceDto dto)
        {
            balanceService.TopUp(dto);
            return Ok(dto);
        }
    }
}
