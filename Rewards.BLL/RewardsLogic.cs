using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rewards.BLL.Interface;
using Rewards.DAL.Interface;
using Rewards.Entities;

namespace Rewards.BLL
{
    public class RewardsLogic : IRewardsLogic
    {
        private readonly IRewardDao _rewardDao;
        
        #region Constructor
        public RewardsLogic(IRewardDao rewardDao)
        {
            _rewardDao = rewardDao;
        }
        #endregion

        #region Methods
        public void Add(int PersonId, int MedalId)
        {
            _rewardDao.Add(PersonId, MedalId);
        }

        public void Delete(int PersonId, int MedalId)
        {
            _rewardDao.Delete(PersonId, MedalId);
        }

        public IEnumerable<Reward> GetAll()
        {
            return _rewardDao.GetAll();
        }
        #endregion
    }
}
