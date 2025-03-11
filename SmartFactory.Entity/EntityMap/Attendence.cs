using System;
using SqlSugar;

namespace SmartFactory.Entity.EntityMap
{
    /// <summary>
    /// 考勤记录实体类
    /// </summary>
    public partial class Attendance
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        /// <summary>
        /// 考勤记录ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 员工ID
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 考勤日期
        /// </summary>
        public DateTime AttendanceDate { get; set; }

        /// <summary>
        /// 上班打卡时间
        /// </summary>
        public DateTime? ClockInTime { get; set; }

        /// <summary>
        /// 下班打卡时间
        /// </summary>
        public DateTime? ClockOutTime { get; set; }

        /// <summary>
        /// 考勤状态（例如：正常、迟到、旷工等）
        /// </summary>
        public string AttendanceStatus { get; set; }
    }
}
