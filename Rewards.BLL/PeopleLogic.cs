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
    public class PeopleLogic : IPeopleLogic
    {
        private readonly IPersonDao _personDao;

        #region Constructor
        public PeopleLogic(IPersonDao personDao)
        {
            _personDao = personDao;
        }
        #endregion

        #region Methods
        public void Add(string name, string surname, string dateOfBirth, int age, string city, string street, string house_number)
        {
            _personDao.Add(name, surname, dateOfBirth, age, city, street, house_number);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            return _personDao.GetAll();
        }

        public void Update(int id, string name, string surname, string dateOfBirth, int age, string city, string street, string house_number)
        {
            _personDao.Update(id, name, surname, dateOfBirth, age, city, street, house_number);
        }
        #endregion
    }
}
