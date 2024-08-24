using Microsoft.EntityFrameworkCore;
using System.Text;
using Mango.Services.RewardAPI.Data;
using Mango.Services.RewardAPI.Models;
using Mango.Services.RewardAPI.Message;

namespace Mango.Services.RewardAPI.Services
{
    public class RewardService : IRewardService
    {
        private DbContextOptions<AppDbContext> _dbOptions;

        public RewardService(DbContextOptions<AppDbContext> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task UpdateRewards(RewardMessage rewardMessage)
        {
            Rewards rewards = new Rewards
            {
                OrderId = rewardMessage.OrderId,
                RewardsActivity = rewardMessage.RewardsActivity,
                UserId = rewardMessage.UserId,
                RewardsDate = DateTime.Now
            };

            await using var _db = new AppDbContext(_dbOptions);
            _db.Rewards.Add(rewards);
            await _db.SaveChangesAsync();
            
        }
    }
}
