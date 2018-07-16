using Rewards.Entities;
using System;
using System.Collections.Generic;

namespace Rewards.DAL.Interface
{
    public interface IPersonDao
    {
        int Add(string name, string surname, DateTime dateOfBirth, int age, string city, string street, string house_number);
        void Update(int id, string name, string surname, DateTime dateOfBirth, int age, string city, string street, string house_number);
        void Delete(int id);
        Person GetById(int id);
        IEnumerable<Person> GetAll();
    }
}
