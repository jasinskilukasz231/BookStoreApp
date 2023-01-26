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
            id[0] = "2";
            id[1] = "334";
            id[2] = "4";
            id[3] = "4";
            id[4] = "4";
            id[5] = "7";
            id[6] = "2";
            //Act
            string result = UtilitiesClass.RemoveSameNumbers(id);
            //Assert
            Assert.Equal("2,334,4,7,", result);
        }
    }
}