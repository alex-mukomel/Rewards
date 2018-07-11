using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rewards.Entities;

namespace Rewards.DAL.Interface
{
    public interface IMedalDao
    {
        void Add(string name, string material);
        void Update(int id, string name, string material);
        int Delete(int id);
        Medal GetById(int id);
        IEnumerable<Medal> GetAll();
    }
}
