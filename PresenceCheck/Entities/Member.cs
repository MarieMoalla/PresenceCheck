using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceCheck.Entities
{
    public class Member
    {
        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string fbLink { get; set; }
        public string phone { get; set; }
        public string dept { get; set; }
        public int nbAbs { get; set; }
        public int nbDelay { get; set; }
        public int yellowCard { get; set; }
        public int redCard { get; set; }

        // meeting list
        public ICollection<Meeting> meetings { get; set; }
    }
}
