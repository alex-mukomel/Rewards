using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rewards.Entities;

namespace Rewards.DAL.Interface
{
    public interface IPersonDao
    {
        void Add(string name, string surname, string dateOfBirth, int age, string city, string street, string house_number);
        void Update(int id, string name, string surname, string dateOfBirth, int age, string city, string street, string house_number);
        int Delete(int id);
        Medal GetById(int id);
        IEnumerable<Person> GetAll();
    }
}
