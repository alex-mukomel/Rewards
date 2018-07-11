using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rewards.DAL.Interface;
using Rewards.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Rewards.DAL
{
    public class RewardFakeDao //: IRewardDao
    {
        /*
        private static HashSet<Reward> _storangeRewards =
            new HashSet<Reward>();

        public int Add(Reward reward)
        {
            int max = 0;
            if (_storangeRewards.Any())
            {
                max = _storangeRewards.Max(item => item.Id);
            }

            reward.Id = ++max;
            _storangeRewards.Add(reward);

            return max;
        }

        public void Update(Reward rewards)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public Reward GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reward> GetAll()
        {
            return _storangeRewards;
        }
        */
    }
}
