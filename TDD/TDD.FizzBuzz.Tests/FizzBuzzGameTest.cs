using FluentAssertions;

namespace TDD.FizzBuzz.Tests
{
    public class FizzBuzzGameTest
    {
        //[Fact]
        //public void It_is_Exists()
        //{
        //    //Test yazma süreci, Red-Green-Refactor yaklaşımı ile ilerler.
        //    var game = new FizzBuzzGame();
        //    var number = 3;
        //    var result = game.GetWord(number);



        //}

        FizzBuzzGame game = new();


        [Fact] 
        public void When_Number_Is_1_Then_Result_Is_1()
        {
            //Arrange:
            var game = new FizzBuzzGame();
            var number = 1;
            //Act:
            var result = game.GetWord(number);
            //Assert:
            //Assert.Equal("1", result);
            result.Should().Be("1");
        }

        [Fact]
        public void When_Number_Is_3_Then_Result_Is_Fizz()
        {
            //Arrange:
            var game = new FizzBuzzGame();
            var number = 3;

            //Act:
            var result = game.GetWord(number);

            //Assert:
            //Assert.Equal("Fizz", result);
            result.Should().Be("Fizz");
        }

        [Fact]
        public void When_Number_Is_5_Then_Result_Is_Buzz()
        {
            var number = 5;
            var result = game.GetWord(number);
            result.Should().Be("Buzz");
        }

        [Theory]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        public void When_Send_Multiply_3_Return_Fizz(int number)
        {
         
            var result = game.GetWord(number);
            result.Should().Be("Fizz");
        }

        
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(35)]
        public void When_Send_Multiply_5_Return_Buzz(int number)
        {

            var result = game.GetWord(number);
            result.Should().Be("Buzz");
        }



        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void When_Send_Multiply_15_Return_FizzBuzz(int number)
        {

            var result = game.GetWord(number);
            result.Should().Be("FizzBuzz");
        }

    }
}
