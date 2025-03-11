using SmartFactory.Entity.EntityMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFactory.BusinessInterface
{
    public interface IAttendanceService : IBaseService
    {
        /// <summary>
        /// 添加考勤记录
        /// </summary>
        /// <param name="attendance">考勤记录实体</param>
        void AddAttendance(Attendance attendance);

        /// <summary>
        /// 根据员工ID和日期查询考勤记录
        /// </summary>
        /// <param name="employeeId">员工ID</param>
        /// <param name="attendanceDate">考勤日期</param>
        /// <returns>考勤记录实体</returns>
       Attendance GetAttendanceByEmployeeIdAndDate(int employeeId, DateTime attendanceDate);
    }
}
