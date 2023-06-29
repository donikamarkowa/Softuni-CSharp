namespace HouseRentingSystem.Web.Controllers
{
    using HouseRentingSystem.Services.Data.Interfaces;
    using HouseRentingSystem.Web.Infrastructure.Extensions;
    using HouseRentingSystem.Web.ViewModels.Agent;
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
                this.TempData[ErrorMessage] = "You are already an agent";

                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            string? userId = this.User.GetId();
            bool isAgent = await this.agentService.AgentsExistByUserIdAsync(userId);
            if (isAgent)
            {
                this.TempData[ErrorMessage] = "You are already an agent";

                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTakes = 
                await this.agentService.AgentsExistByPhoneNumberAsync(model.PhoneNumber);

            if (isPhoneNumberTakes)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Agent with the provided phone number already exist!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            bool userHasActiveRengts = await this.agentService
                .HasRentsByUserIdAsync(userId);
            if (userHasActiveRengts)
            {
                this.TempData[ErrorMessage] = "You must not have any active rents in order to become an agent!";

                return RedirectToAction("Mine", "House");
            }

            try
            {
                await this.agentService.Create(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = 
                    "Unexpected error occurred while registering you as an agent! Please try again later or constant administrator!";

                return this.RedirectToAction("Index", "Home");  
            }

            return this.RedirectToAction("All", "House");
        }
    }
}
