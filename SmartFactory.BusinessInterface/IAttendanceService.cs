using SmartFactory.Entity.EntityMap;
using SmartFactory.Entity.EntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Zhaoxi.SmartFactory.Common.Result;

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
       AttendanceWithUserName GetAttendanceByEmployeeIdAndDate(int employeeId, DateTime attendanceDate);
        PagingData<AttendanceWithUserName> QueryPageAttendanceWithUsername(Expression<Func<Attendance, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<AttendanceWithUserName, object>> funcOrderby, bool isAsc = true);

    }
}
