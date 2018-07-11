using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rewards.Entities;

namespace Rewards.DAL.Interface
{
    public interface IRewardDao
    {
        int Add(int PersonId, int MedalId);

        void Delete(int PersonId, int MedalId);

        //Reward GetById(int id);

        IEnumerable<Reward> GetAll();
    }
}
