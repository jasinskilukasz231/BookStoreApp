using Xunit;

namespace BookStoreApp.test
{
    public class UtilitiesTest
    {
        [Fact]
        public void RemoveSameNumbersTest()
        {
            //this method works propertly but the order of numbers is incorect
            //Arrange
            string[] id = new string[10];


            //Act
            string result = UtilitiesClass.RemoveSameNumbers(id);
            //Assert
            Assert.Equal("", result);
        }
    }
}