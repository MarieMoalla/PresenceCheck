using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceCheck.Entities
{
    public enum Pstate
    {
        a,
        p,
        r
    }
    public class Meeting
    {
        public long id { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public Pstate state { get; set; }
        // fk
        public Member member { get; set; }
        public long memberId { get; set; }
    }
}
