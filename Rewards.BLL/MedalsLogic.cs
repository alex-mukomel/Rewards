using Rewards.BLL.Interface;
using Rewards.DAL.Interface;
using Rewards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rewards.BLL
{
    public class MedalsLogic : IMedalsLogic
    {
        #region Fields
        private readonly IMedalDao _medalDao;
        #endregion

        #region Constructor
        public MedalsLogic(IMedalDao medalDao)
        {
            _medalDao = medalDao;
        }
        #endregion

        #region Methods
        public int Add(string name, string material)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(material))
            {
                throw new ArgumentNullException("It is not possible to ADD a medal without a name or material.");
            }
            else
            {
                return _medalDao.Add(name, material);
            }
        }

        public void Update(int id, string name, string material)
        {
            if (_medalDao.GetById(id) == null)
            {
                throw new Exception($"Medal with id = {id} not available");
            }
            else
            {
                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(material))
                {
                    throw new ArgumentNullException("It is not possible to UPDATE a medal without a name or material.");
                }
                else
                {
                    _medalDao.Update(id, name, material);
                }
            }
        }

        public void Delete(int id)
        {
            if (_medalDao.GetById(id) == null || OccursInReward(id))
            {
                throw new Exception("Someone is awarded this medal or a medal does not exist."); 
            }
            else
            {
                _medalDao.Delete(id);
            }
        }

        public Medal GetById(int id)
        {
            return _medalDao.GetById(id);
        }

        public bool OccursInReward(int id)
        {
            return _medalDao.OccursInReward(id);
        }

        public IEnumerable<Medal> GetAll()
        {
            return _medalDao.GetAll().ToList();
        }
        #endregion
    }
}
