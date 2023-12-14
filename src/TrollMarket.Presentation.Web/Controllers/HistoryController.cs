using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TrollMarket.Presentation.Web.Services;

namespace TrollMarket.Presentation.Web.Controllers
{
    [Authorize(Roles = "admin")]

    public class HistoryController : Controller
    {
        private readonly HistoryService historyService;
        public HistoryController(HistoryService historyService)
        {
            this.historyService = historyService;
        }
        public IActionResult Index(int? buyerId, int? sellerId)
        {
            var vm = historyService.GetHistoryIndexViewModel(buyerId, sellerId);
            return View(vm);
        }
    }
}
