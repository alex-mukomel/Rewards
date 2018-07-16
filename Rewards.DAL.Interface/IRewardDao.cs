using System.Collections.Generic;

namespace Rewards.DAL.Interface
{
    public interface IRewardDao
    {
        void Add(int PersonId, int MedalId);
        void Delete(int PersonId, int MedalId);
        bool IsPersonCreated(int id);
        bool IsMedalCreated(int id);
        IEnumerable<string> GetAll();
    }
}
