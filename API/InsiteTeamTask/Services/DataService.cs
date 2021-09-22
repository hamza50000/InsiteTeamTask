using InsiteTeamTask.Data.Models;
using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsiteTeamTask.Services
{
	public class DataService : IDataService
	{
		private readonly IDataProvider _dataProvider;

		public DataService(IDataProvider dataProvider)
		{
			_dataProvider = dataProvider;
		}


		/// <summary>
		/// Fetches All attendance.
		/// </summary>
		/// <returns> List of attendances</returns>
		public List<Attendance> GetAttendance()
		{
			try
			{
				var products = _dataProvider.GetProducts();
				var attendance = new List<Attendance>(); // initializing attendance list
				if (products != null && products.Count() > 0) // checking null and count of fetched data
				{
					// iterate through products list to get the required data
					foreach (var product in products)
					{
						if (product.Type == ProductType.Ticket) // checking the product type
						{
							var tickets = _dataProvider.GetTickets().Where(x => x.ProductId == product.Id); // for ticket type fetch tickets

							// iterate through tickets and map into attendance object
							var list = tickets.Select(x => new Attendance
							{
								AttendanceType = AttendanceType.GameTicket,
								Barcode = x.Barcode,
								Game = _dataProvider.GetGames().FirstOrDefault(y => y.Id == product.GameId).Description,
								Season = _dataProvider.GetSeasons().FirstOrDefault(y => y.Id == product.SeasonId).Name
							}).ToList();

							// adding list into attendance list
							attendance.AddRange(list);
							
						}
						else if (product.Type == ProductType.Member) // checking product type
						{
							var members = _dataProvider.GetMembers().Where(x => x.ProductId == product.Id); // for member type fetch members

							// iterate through members and map into attendance object
							var list = members.Select(x => new Attendance
							{
								AttendanceType = AttendanceType.SeasonTicket,
								MemberId = x.Id,
								Game = "All",
								Season = _dataProvider.GetSeasons().FirstOrDefault(y => y.Id == product.SeasonId).Name
							}).ToList();

							// adding list into attendance list
							attendance.AddRange(list);
						}
					}
				}
				return attendance;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}


		/// <summary>
		/// Fetches Attendances for the Game.
		/// </summary>
		/// <param name="seasonId"> Season ID is the int value</param>
		/// <param name="gameNumber"> Game ID is the int value</param>
		/// <returns> List of attendances</returns>
		public List<Attendance> GetAttendanceForGame(int seasonId, int gameNumber)
		{
			try
			{
				// fetch the unique product on the basis of combination of season id and game id
				var product = _dataProvider.GetProducts().FirstOrDefault(x => x.GameId == gameNumber && x.SeasonId == seasonId);
				var attendance = new List<Attendance>();
				if (product != null) // check null condition
				{
					if (product.Type == ProductType.Ticket) // check the product type
					{
						// fetch the tickets for product type ticket and given product
						var tickets = _dataProvider.GetTickets().Where(x => x.ProductId == product.Id);

						// iterate through tickets and map into attendance object
						var list = tickets.Select(x => new Attendance
						{
							AttendanceType = AttendanceType.GameTicket,
							Barcode = x.Barcode,
							Game = _dataProvider.GetGames().FirstOrDefault(y => y.Id == product.GameId).Description,
							Season = _dataProvider.GetSeasons().FirstOrDefault(y => y.Id == product.SeasonId).Name
						}).ToList();

						// adding list into attendance list
						attendance.AddRange(list);
					}
					else if (product.Type == ProductType.Member) // check the product type
					{
						// fetch the members for product type member and given product
						var members = _dataProvider.GetMembers().Where(x => x.ProductId == product.Id);

						// iterate through members and map into attendance object
						var list = members.Select(x => new Attendance
						{
							AttendanceType = AttendanceType.SeasonTicket,
							MemberId = x.Id,
							Game = "All",
							Season = _dataProvider.GetSeasons().FirstOrDefault(y => y.Id == product.SeasonId).Name
						}).ToList();

						// adding list into attendance list
						attendance.AddRange(list);
					}
				}
				return attendance;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}


		/// <summary>
		/// Fetches Attendances for the Product.
		/// </summary>
		/// <param name="productCode"> Product ID is the string value</param>
		/// <returns> List of attendances</returns>
		public List<Attendance> GetAttendanceForProduct(string productCode)
		{
			try
			{
				// fetch the unique product on the basis of product id i.e. productCode
				var product = _dataProvider.GetProducts().FirstOrDefault(x => x.Id == productCode);
				var attendance = new List<Attendance>();
				if (product != null) // check the null condition
				{
					if (product.Type == ProductType.Ticket) // check the product type
					{

						// fetch the tickets for product type ticket and given product
						var tickets = _dataProvider.GetTickets().Where(x => x.ProductId == product.Id);

						// iterate through tickets and map into attendance object
						var list = tickets.Select(x => new Attendance
						{
							AttendanceType = AttendanceType.GameTicket,
							Barcode = x.Barcode,
							Game = _dataProvider.GetGames().FirstOrDefault(y => y.Id == product.GameId).Description,
							Season = _dataProvider.GetSeasons().FirstOrDefault(y => y.Id == product.SeasonId).Name
						}).ToList();

						// adding list into attendance list
						attendance.AddRange(list);
					}
					else if (product.Type == ProductType.Member) // check the product type
					{
						// fetch the members for product type member and given product
						var members = _dataProvider.GetMembers().Where(x => x.ProductId == product.Id);

						// iterate through members and map into attendance object
						var list = members.Select(x => new Attendance
						{
							AttendanceType = AttendanceType.SeasonTicket,
							MemberId = x.Id,
							Game = "All",
							Season = _dataProvider.GetSeasons().FirstOrDefault(y => y.Id == product.SeasonId).Name
						}).ToList();

						// adding list into attendance list
						attendance.AddRange(list);
					}
				}
				return attendance;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}
	}
}
