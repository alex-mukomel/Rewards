using Rewards.BLL.Interface;
using Rewards.DAL.Interface;
using Rewards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rewards.BLL
{
    public class PeopleLogic : IPeopleLogic
    {
        #region Fields
        private readonly IPersonDao _personDao;
        #endregion

        #region Constructor
        public PeopleLogic(IPersonDao personDao)
        {
            _personDao = personDao;
        }
        #endregion

        #region Methods
        public int Add(string name, string surname, DateTime dateOfBirth, int age, string city, string street, string house_number)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(surname))
            {
                throw new ArgumentNullException("It is not possible to ADD a person without a name or surname.");
            }
            else
               if (DateTime.Now < dateOfBirth)
            {
                throw new ArgumentException("Incorrect date of birth.");
            }
            else
               if (DateTime.Now.Year - dateOfBirth.Year > age || DateTime.Now.Year - dateOfBirth.Year < age - 1)
            {
                throw new ArgumentException("Age does not match the date of birth.");
            }
            else
               if (String.IsNullOrEmpty(city) || Regex.IsMatch(city, @"\d"))
            {
                throw new ArgumentException("Invalid City name.");
            }
            else
               if (String.IsNullOrEmpty(street))
            {
                throw new ArgumentNullException("Invalid Street name (null value).");
            }
            else
               if (String.IsNullOrEmpty(house_number) || !Regex.IsMatch(house_number, @"\d"))
            {
                throw new ArgumentException("Invalid House number.");
            }
            else
            {
                return _personDao.Add(name, surname, dateOfBirth, age, city, street, house_number);
            }
        }

        public void Update(int id, string name, string surname, DateTime dateOfBirth, int age, string city, string street, string house_number)
        {
            if (_personDao.GetById(id) == null)
            {
                throw new Exception("Person does not exist.");
            }
            else
                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(surname))
            {
                throw new ArgumentNullException("It is not possible to UPDATE a person without a name or surname.");
            }
            else
                if (DateTime.Now < dateOfBirth)
            {
                throw new ArgumentException("Incorrect date of birth.");
            }
            else
                if (DateTime.Now.Year - dateOfBirth.Year > age || DateTime.Now.Year - dateOfBirth.Year < age - 1)
            {
                throw new ArgumentException("Age does not match the date of birth.");
            }
            else
                if (String.IsNullOrEmpty(city) || Regex.IsMatch(city, @"\d"))
            {
                throw new ArgumentException("Invalid City name.");
            }
            else
                if (String.IsNullOrEmpty(street))
            {
                throw new ArgumentNullException("Invalid Street name (null value).");
            }
            else
                if (String.IsNullOrEmpty(house_number) || !Regex.IsMatch(house_number, @"\d"))
            {
                throw new ArgumentException("Invalid House number.");
            }
            else
            {
                _personDao.Update(id, name, surname, dateOfBirth, age, city, street, house_number);
            }
        }

        public void Delete(int id)
        {
            if (_personDao.GetById(id) == null)
            {
                throw new Exception("Person wasn't created. You can't remove it");
            }
            else
            {
                _personDao.Delete(id);
            }
        }

        public Person GetById(int id)
        {
            return _personDao.GetById(id);
        }

        public IEnumerable<Person> GetAll() //мб убрать ToList()
        {
            return _personDao.GetAll().ToList();
        }
        #endregion
    }
}
