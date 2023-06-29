using HouseRentingSystem.Web.ViewModels.Agent;

namespace HouseRentingSystem.Services.Data.Interfaces
{
    public interface IAgentService
    {
        Task<bool> AgentsExistByUserIdAsync(string userId);

        Task<bool> AgentsExistByPhoneNumberAsync(string phoneNumber);

        Task<bool> HasRentsByUserIdAsync(string userId);

        Task Create(string userId, BecomeAgentFormModel model);
    }
}
