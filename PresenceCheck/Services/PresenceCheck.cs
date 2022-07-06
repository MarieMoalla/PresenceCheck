using Microsoft.EntityFrameworkCore;
using PresenceCheck.Data;
using PresenceCheck.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceCheck.Services
{
    public interface IPresenceCheck
    {
        Task<string> MarkPresence(Member member,Pstate state);
    }
    public class PresenceCheck : IPresenceCheck
    {
        #region variables
        private readonly AppDBContext _context;
        private readonly ICardCheck _card;
        public PresenceCheck(ICardCheck card, AppDBContext context)
        {
            _context = context;
            _card = card;
        }
        #endregion

        public async Task<string> MarkPresence(Member member, Pstate state)
        {
            try
            {
                if (state == Pstate.a) { member.nbAbs++; await _card.MarkCard(member, "yellow"); }
                if (state == Pstate.r) { member.nbDelay++; if (member.nbDelay % 3 == 0) await _card.MarkCard(member, "yellow"); }

                _context.Entry(member).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                string result = await _card.CheckCard(member);
                return result;
            }
            catch(Exception ex){ return ex.Message; }
        }
    }
}
