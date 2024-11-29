using Kommunity.API.Data;
using Kommunity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kommunity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController(SpeakersDbContext dbContext) : ControllerBase
    {
        [HttpGet("[action]/{name}")]
        [Route("api/[controller]/search",Name ="Get")]
        public IActionResult Search(string name)
        {
            //Daha doğru bir yaklaşım için, başka bir instance'dan alınmalıdır.
            var speakers = new List<Speaker>()
            {
                new Speaker() { Name = "Türkay" },
                new Speaker() { Name = "Ercan" },
                new Speaker() { Name = "Mehmet" },
                new Speaker() { Name = "Türker" },
                new Speaker() { Name = "Türkan" },

            };
            var result = speakers.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();  
            return Ok(result);
        }

        public IResult Create(Speaker speaker)
        {
            //Speaker kaydedildiğinde, kaydedilen kaydın id'si dönmelidir.
            dbContext.Speakers.Add(speaker);
            dbContext.SaveChanges();
            return Results.CreatedAtRoute("Get", routeValues: new { id = speaker.Id }, value:speaker.Id);
        }
    }
}
