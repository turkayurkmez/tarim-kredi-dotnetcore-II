using FluentAssertions;
using Kommunity.API.Models;
using Kommunity.API.Tests.Fixtures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kommunity.API.Tests
{
    //1. Web Api'yi ayağa kaldırmak için Fixture oluşturulmalıdır.
    public class KommunityApiTests : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private readonly InMemoryWebApplicationFactory<Program> _factory;

        public KommunityApiTests(InMemoryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task web_api_get_request()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/speakers/search/türk");
            var ouput = await response.Content.ReadAsStringAsync();
            var speakers = JsonConvert.DeserializeObject<List<Speaker>>(ouput);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            speakers.Count.Should().Be(3);


        }

        //test web api post request
        [Fact]
        public async Task web_api_post_request()
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/speakers", new StringContent(JsonConvert.SerializeObject(new Speaker { Name = "Türkay", Bio = "Software Developer" }), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
