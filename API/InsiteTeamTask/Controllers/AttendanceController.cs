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
        private readonly IDataService _service;

        public AttendanceController(IDataService service)
		{
            _service = service;
		}

        [HttpGet]
        [Route("GetAttendance")]
        public IActionResult Get()
        {
            var attendance = _service.GetAttendance();
            return Ok(attendance);
        }

        [HttpGet]
        [Route("GetAttendance/{productCode}")]
        public IActionResult Get(string productCode)
        {
            var attendance = _service.GetAttendanceForProduct(productCode);
            return Ok(attendance);
        }

        [HttpGet]
        [Route("GetAttendance/{seasonId}/{gameNumber}")]
        public IActionResult Get(int seasonId, int gameNumber)
        {
            var attendance = _service.GetAttendanceForGame(seasonId, gameNumber);
            return Ok(attendance);
        }
    }
}
