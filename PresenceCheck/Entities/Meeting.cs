using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PresenceCheck.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
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
        public DateTime date { get; set; }
        public Pstate state { get; set; }
        // fk
        public Member member { get; set; }
        public long memberId { get; set; }
    }
}
