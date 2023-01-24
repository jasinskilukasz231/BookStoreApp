using Xunit;

namespace BookStoreApp.test
{
    public class UtilitiesTest
    {
        [Fact]
        public void RemoveSameNumbersTest()
        {
            //Arrange
            string[] id = new string[10];
            id[0] = "2";
            id[1] = "33";
            id[2] = "4";
            id[3] = "2";
            id[4] = "2";
            id[5] = "33";
            id[6] = "33";
            id[7] = "6";
            id[8] = "7";
            id[9] = "8";
            //Act
            string result = UtilitiesClass.RemoveSameNumbers(id);
            //Assert
            Assert.Equal("4,2,33,6,7,8,", result);
        }
    }
}