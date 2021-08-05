using InsiteTeamTask.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsiteTeamTask.Tests
{
    [TestClass]
    public class InsiteTeamTaskTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var mockDataService = new DataService();
 
            // Act
            var attendance = mockDataService.GetAttendance();

            // Assert
            Assert.IsNotNull(attendance);
        }
    }
}
