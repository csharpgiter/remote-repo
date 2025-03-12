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
        /// <summary>
        /// 分页查询考勤记录（这是一个联表查询）
        /// </summary>
        /// <param name="funcWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="funcOrderby"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        PagingData<AttendanceWithUserName> QueryPageAttendanceWithUsername(Expression<Func<Attendance, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<AttendanceWithUserName, object>> funcOrderby, bool isAsc = true);

        /// <summary>
        /// 根据考勤记录ID删除考勤记录
        /// </summary>
        /// <param name = "attendanceId" > 考勤记录ID </ param >
        /// < returns > 删除是否成功 </ returns >
        bool DeleteAttendance(int attendanceId);

        /// <summary>
        /// 修改考勤记录
        /// </summary>
        /// <param name = "attendance" > 考勤记录实体 </ param >
        /// < returns > 修改是否成功 </ returns >
        bool UpdateAttendance(Attendance attendance);
    }
}
