using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewards.Entities
{
    public class Reward
    {
        public int PersonId { get; set; }
        public int MedalId { get; set; }

        ///
        public override int GetHashCode()
        {
            return PersonId.GetHashCode() ^ MedalId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Reward value))
            {
                throw new ArgumentException("obj is not Reward");
            }

            return value.PersonId.Equals(this.PersonId);
        }
    }
}
