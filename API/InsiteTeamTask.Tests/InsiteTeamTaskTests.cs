using InsiteTeamTask.Data.Providers;
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
			IDataProvider dataProvider = new DataProvider();
			var mockDataService = new DataService(dataProvider);

			// Act
			var attendance = mockDataService.GetAttendance();

			// Assert
			Assert.IsNotNull(attendance);
		}

		[TestMethod]
		[DataRow("MN319A")]
		[DataRow("")]
		public void TestMethod2(string productCode)
		{
			// Arrange
			IDataProvider dataProvider = new DataProvider();
			var mockDataService = new DataService(dataProvider);

			// Act
			var attendance = mockDataService.GetAttendanceForProduct(productCode);

			// Assert
			Assert.IsNotNull(attendance);
		}

		[TestMethod]
		[DataRow(12,3)]
		[DataRow(0, 0)]
		public void TestMethod3(int seasonId, int gameNumber)
		{
			// Arrange
			IDataProvider dataProvider = new DataProvider();
			var mockDataService = new DataService(dataProvider);

			

			// Act
			var attendance = mockDataService.GetAttendanceForGame(seasonId, gameNumber);

			// Assert
			Assert.IsNotNull(attendance);
		}
	}
}
