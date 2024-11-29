using Kommunity.API.Data;
using Kommunity.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kommunity.API.Tests.Fixtures
{
    public class TestSpeakerDbContext : SpeakersDbContext
    {
        public TestSpeakerDbContext(DbContextOptions<SpeakersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            using (StreamReader reader = new StreamReader("../../../TestData/speakers.json"))
            {
                var json = reader.ReadToEnd();
                var speakers = JsonConvert.DeserializeObject<List<Speaker>>(json);
                modelBuilder.Entity<Speaker>().HasData(speakers);
            }
        }

    }
}
