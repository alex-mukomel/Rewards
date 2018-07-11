using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rewards.Entities;

namespace Rewards.BLL.Interface
{
    public interface IRewardsLogic
    {
        void Add(int PersonId, int MedalId);
        void Delete(int PersonId, int MedalId);
        IEnumerable<Reward> GetAll();
    }
}
