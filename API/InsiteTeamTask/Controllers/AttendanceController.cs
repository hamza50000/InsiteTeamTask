using System.Collections.Generic;
using InsiteTeamTask.Services;
using InsiteTeamTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsiteTeamTask.Controllers
{
    [Route("api/Attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IDataService service;

        [HttpGet]
        public IEnumerable<Attendance> Get()
        {
            var attendance = service.GetAttendance();
            return attendance;
        }
    }
}
