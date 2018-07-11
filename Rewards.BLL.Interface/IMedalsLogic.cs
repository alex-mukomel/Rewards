using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rewards.Entities;

namespace Rewards.BLL.Interface
{
    public interface IMedalsLogic
    {
        void Add(string name, string material);
        void Delete(int id);
        void Update(int id, string name, string material);
        IEnumerable<Medal> GetAll();

    }
}
