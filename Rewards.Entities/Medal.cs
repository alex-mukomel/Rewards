using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewards.Entities
{
    public class Medal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }

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
