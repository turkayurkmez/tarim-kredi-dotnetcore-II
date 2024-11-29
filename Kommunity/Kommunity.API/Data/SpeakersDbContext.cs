using Kommunity.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Kommunity.API.Data
{
    public class SpeakersDbContext : DbContext
    {
        public SpeakersDbContext(DbContextOptions<SpeakersDbContext> options) : base(options)
        {
        }
        public DbSet<Speaker> Speakers { get; set; }
    }
}
