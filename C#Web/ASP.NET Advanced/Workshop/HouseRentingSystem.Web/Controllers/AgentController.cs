namespace HouseRentingSystem.Web.Controllers
{
    using HouseRentingSystem.Services.Data.Interfaces;
    using HouseRentingSystem.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Claims;
    using static HouseRentingSystem.Common.NotificationMessagesConstants;
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();
            bool isAgent = await this.agentService.AgentsExistByUserIdAsync(userId);
            if (isAgent)
            {
                TempData[ErrorMessage] = "You are already an agent";

                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
