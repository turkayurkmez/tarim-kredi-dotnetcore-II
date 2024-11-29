using FluentAssertions;
using Kommunity.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kommunity.API.Tests
{
    public class SpeakerApiControllerTests
    {
        //[Fact]
        //public void It_Exists()
        //{
        //    var controller = new Kommunity.API.Controllers.SpeakersController();
        //    string name = string.Empty;
        //    controller.Search(name);
        //}

        //testing search method must return OkObjectResult
        //[Fact]
        //public void Search_Returns_OkObjectResult()
        //{
        //    // Arrange
        //    var controller = new Kommunity.API.Controllers.SpeakersController();
        //    // Act
        //    var result = controller.Search("name");
        //    // Assert
        //    result.Should().BeOfType<OkObjectResult>();
        //}

        //[Fact]
        //public void Search_Returns_Collection_of_Speakers()
        //{
        //    // Arrange
        //    var controller = new Kommunity.API.Controllers.SpeakersController();
        //    // Act
        //    var result = controller.Search("name") as OkObjectResult;
        //    result.Should().NotBeNull();
        //    result.Value.Should().NotBeNull();
        //    result.Value.Should().BeOfType<List<Speaker>>();
        //    // Assert

        //}

        //[Fact]
        //public void Given_Exact_match_then_return_one_speaker() {
        //    // Arrange
        //    var controller = new Kommunity.API.Controllers.SpeakersController();
        //    var name = "Türkay";
        //    // Act

        //    var result = controller.Search(name) as OkObjectResult;         
          
        //    var speakers = result.Value as List<Speaker>;
        //    speakers.Count.Should().Be(1);
        //    // Assert
        //}

        ////testing given name is case insensitive match then return speaker collection
        //[Fact]
        //public void Given_Case_Insensitive_match_then_return_speaker_collection()
        //{
        //    // Arrange
        //    var controller = new Kommunity.API.Controllers.SpeakersController();
        //    var name = "türkay";
        //    // Act
        //    var result = controller.Search(name) as OkObjectResult;
        //    var speakers = result.Value as List<Speaker>;
        //    // Assert
        //    speakers.First().Name.Should().Be("Türkay");
        //}




    }
}
