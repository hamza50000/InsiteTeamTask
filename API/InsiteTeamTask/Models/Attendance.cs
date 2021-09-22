namespace InsiteTeamTask.Models
{
    public enum AttendanceType
    {
        SeasonTicket,
        GameTicket
    }

    public class Attendance
    {
        public AttendanceType AttendanceType { get; set; }

        public int MemberId { get; set; }

        public string Barcode { get; set; }

        public string Season { get; set; }

        public string Game { get; set; }
    }
}