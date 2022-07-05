using Microsoft.EntityFrameworkCore;
using PresenceCheck.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresenceCheck.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            builder.Entity<Member>().HasMany<Meeting>(g => g.meetings).WithOne(s => s.member).HasForeignKey(s => s.memberId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Meeting>().HasOne<Member>(g => g.member).WithMany(s => s.meetings).HasForeignKey(d=>d.memberId).OnDelete(DeleteBehavior.Restrict);
           
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

    }
}
