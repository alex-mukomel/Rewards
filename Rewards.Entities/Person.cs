using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewards.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string NumberOfHouse { get; set; }

        ///
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person value))
            {
                throw new ArgumentException("obj is not Reward");
            }

            return value.Id.Equals(this.Id);
        }
    }
}
