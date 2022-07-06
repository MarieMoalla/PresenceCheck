using Microsoft.EntityFrameworkCore;
using PresenceCheck.Data;
using PresenceCheck.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceCheck.Services
{
    public interface ICardCheck
    {
        Task<string> CheckCard(Member member);
        Task<string> MarkCard(Member member,string color);
    }
    public class CardCheck : ICardCheck
    {
        #region variables
        private readonly AppDBContext _context;
        public CardCheck(AppDBContext context)
        {
            _context = context;
        }
        #endregion
        public async Task<string> CheckCard(Member member)
        {
            if (member.yellowCard % 3 == 0) MarkCard(member, "red"); 
            return "done";
            
        }
        public async Task<string> MarkCard(Member member,string color)
        {
            try
            {
                switch (color)
                {
                    case "yellow":
                        {
                            member.yellowCard++;

                            break;
                        }
                    case "red":
                        {
                            member.redCard++;
                            break;
                        }
                    default:
                        {
                            return "wrong color";
                            break;
                        }
                }
                _context.Entry(member).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return "marked";
            }
            catch(Exception ex) { return ex.Message; }
            
        }


       
    }
}
