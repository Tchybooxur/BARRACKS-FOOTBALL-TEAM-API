using Microsoft.EntityFrameworkCore;
using System;

namespace BarracksAllStarsCrudOperationCorePractice.Models
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
