using SmartFactory.BusinessInterface;
using SmartFactory.Entity.EntityDto;
using SmartFactory.Entity.EntityMap;
using SqlSugar;
using System.Linq.Expressions;
using Zhaoxi.SmartFactory.Common.Result;

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

        public AttendanceWithUserName GetAttendanceByEmployeeIdAndDate(int employeeId, DateTime attendanceDate)
        {
            return _Client.Queryable<Attendance, User>((a, u) => new object[] {
                    JoinType.Left, a.EmployeeId == u.Id
                })
                .Where((a, u) => a.EmployeeId == employeeId && a.AttendanceDate == attendanceDate)
                .Select((a, u) => new AttendanceWithUserName
                {
                    Id = a.Id,
                    EmployeeId = a.EmployeeId,
                    AttendanceDate = a.AttendanceDate,
                    ClockInTime = a.ClockInTime,
                    ClockOutTime = a.ClockOutTime,
                    AttendanceStatus = a.AttendanceStatus,
                    UserName = u.UserName
                })
                .First();
        }
        public PagingData<AttendanceWithUserName> QueryPageAttendanceWithUsername(Expression<Func<Attendance, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<AttendanceWithUserName, object>> funcOrderby, bool isAsc = true)
        {
            // 联表查询 Attendance 和 User
            var query = _Client.Queryable<Attendance, User>((a, u) => new object[] {
        JoinType.Left, a.EmployeeId == u.Id
    });

            if (funcWhere != null)
            {
                query = query.Where(funcWhere);
            }

            // 选择需要的字段映射到 AttendanceWithUsername
            var selectQuery = query.Select((a, u) => new AttendanceWithUserName
            {
                Id = a.Id,
                EmployeeId = a.EmployeeId,
                AttendanceDate = a.AttendanceDate,
                ClockInTime = a.ClockInTime,
                ClockOutTime = a.ClockOutTime,
                AttendanceStatus = a.AttendanceStatus,
                UserName = u.UserName
            });

            // 排序
            if (funcOrderby != null)
            {
                selectQuery = selectQuery.OrderByIF(true, funcOrderby, isAsc ? OrderByType.Asc : OrderByType.Desc);
            }

            // 分页
            var totalCount = 0;
            var dataList = selectQuery.ToPageList(pageIndex, pageSize, ref totalCount);

            // 构建分页结果
            PagingData<AttendanceWithUserName> result = new PagingData<AttendanceWithUserName>()
            {
                DataList = dataList,
                PageIndex = pageIndex,
                PageSize = pageSize,
                RecordCount = totalCount
            };

            return result;
        }
    }
}
