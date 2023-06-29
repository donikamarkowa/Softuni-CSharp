namespace HouseRentingSystem.Services.Data.Interfaces
{
    public interface IAgentService
    {
        Task<bool> AgentsExistByUserIdAsync(string userId);

        Task<bool> AgentsExistByPhoneNumberAsync(string phoneNumber);
    }
}
