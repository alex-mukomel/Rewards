using Rewards.BLL.Interface;
using Rewards.DAL.Interface;
using System;
using System.Collections.Generic;

namespace Rewards.BLL
{
    public class RewardsLogic : IRewardsLogic
    {
        #region Fields
        private readonly IRewardDao _rewardDao;
        #endregion

        #region Constructor
        public RewardsLogic(IRewardDao rewardDao)
        {
            _rewardDao = rewardDao;
        }
        #endregion

        #region Methods
        public void Add(int personId, int medalId)
        {
            if (!_rewardDao.IsPersonCreated(personId) || !_rewardDao.IsMedalCreated(medalId))
            {
                throw new Exception("Medal or person wasn't created");
            }
            else
            {
                _rewardDao.Add(personId, medalId);
            }
        }

        public void Delete(int personId, int medalId)
        {
            if (!_rewardDao.IsMedalCreated(personId) || !_rewardDao.IsPersonCreated(medalId))
            {
                throw new Exception("Medal or person wasn't created");
            }
            else
            {
                _rewardDao.Delete(personId, medalId);
            }
        }

        public IEnumerable<string> GetAll()
        {
            return _rewardDao.GetAll();
        }
        #endregion
    }
}
