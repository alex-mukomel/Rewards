using Rewards.Entities;
using System.Collections.Generic;

namespace Rewards.BLL.Interface
{
    public interface IMedalsLogic
    {
        int Add(string name, string material);
        void Update(int id, string name, string material);
        void Delete(int id);
        Medal GetById(int id);
        bool OccursInReward(int id);
        IEnumerable<Medal> GetAll();
    }
}
