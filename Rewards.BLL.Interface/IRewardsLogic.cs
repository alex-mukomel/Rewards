using System.Collections.Generic;

namespace Rewards.BLL.Interface
{
    public interface IRewardsLogic
    {
        void Add(int PersonId, int MedalId);
        void Delete(int PersonId, int MedalId);
        IEnumerable<string> GetAll();
    }
}
