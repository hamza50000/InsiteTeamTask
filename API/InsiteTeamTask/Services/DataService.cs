using InsiteTeamTask.Data.Providers;
using InsiteTeamTask.Models;
using System;
using System.Collections.Generic;

namespace InsiteTeamTask.Services
{
    public class DataService : IDataService
    {
        private readonly IDataProvider dataProvider;

        public List<Attendance> GetAttendance()
        {
            throw new NotImplementedException();
        }

        public List<Attendance> GetAttendanceForGame(int seasonId, int gameNumber)
        {
            throw new NotImplementedException();
        }

        public List<Attendance> GetAttendanceForProduct(string productCode)
        {
            throw new NotImplementedException();
        }
    }
}
