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
    public class MedalsLogic : IMedalsLogic
    {
        private readonly IMedalDao _medalDao;

        #region Constructor
        public MedalsLogic(IMedalDao medalDao)
        {
            _medalDao = medalDao;
        }
        #endregion

        #region Methods
        public void Add(string name, string material)
        {
            _medalDao.Add(name, material);
        }

        public void Delete(int id)
        {
            _medalDao.Delete(id);
        }

        public void Update(int id, string name, string material)
        {
            _medalDao.Update(id, name, material);
        }

        public IEnumerable<Medal> GetAll()
        {
            return _medalDao.GetAll();
        }
        #endregion
    }
}
