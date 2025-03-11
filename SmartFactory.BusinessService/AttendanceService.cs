using SmartFactory.BusinessInterface;
using SmartFactory.Entity.EntityMap;
using SqlSugar;

namespace SmartFactory.BusinessService
{
    public class AttendanceService : BaseService, IAttendanceService
    {
       
        public AttendanceService(ISqlSugarClient client) : base(client)
        {
        }

        public void AddAttendance(Attendance attendance)
        {
            _Client.Insertable(attendance).ExecuteCommand();
        }

        public Attendance GetAttendanceByEmployeeIdAndDate(int employeeId, DateTime attendanceDate)
        {
            return _Client.Queryable<Attendance>()
                .Where(x => x.EmployeeId == employeeId && x.AttendanceDate == attendanceDate)
                .First();
        }
    }
}
