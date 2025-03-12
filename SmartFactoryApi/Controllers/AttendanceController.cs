using Microsoft.AspNetCore.Mvc;
using SmartFactory.BusinessInterface;
using SmartFactory.BusinessService;
using SmartFactory.Entity.EntityMap;
using SmartFactory.Entity.EntityDto;
using SqlSugar;
using Zhaoxi.SmartFactory.Common.Result;

namespace SmartFactoryApi.Controllers
{
    /// <summary>
    /// 考勤管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        /// <summary>
        /// 添加考勤记录
        /// </summary>
        /// <param name="attendance">考勤记录实体</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddAttendance(int  employeeid,string status)
        {
            Attendance attendance = new Attendance()
            {
                EmployeeId = employeeid,
                AttendanceDate = DateTime.Today ,
                ClockInTime = DateTime.Now,
                ClockOutTime = DateTime.Now.AddHours(2),
                AttendanceStatus = status
            };
            _attendanceService.AddAttendance(attendance);
            return Ok();
        }

        /// <summary>
        /// 根据员工ID和日期查询考勤记录
        /// </summary>
        /// <param name="employeeId">员工ID</param>
        /// <param name="attendanceDate">考勤日期</param>
        /// <returns>考勤记录实体</returns>
        [HttpGet("{employeeId:int}/{attendanceDate:datetime}")]
        public IActionResult GetAttendanceByEmployeeIdAndDate(int employeeId, DateTime attendanceDate)
        {
            var attendance = _attendanceService.GetAttendanceByEmployeeIdAndDate(employeeId, attendanceDate);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }
        /// <returns></returns>
        [HttpGet("{pageindex:int}/{pagesize:int}/{startdate:double}/{enddate:double}")]
        [HttpGet("{pageindex:int}/{pagesize:int}")]
        public IActionResult SystemlogPage(int pageindex, int pagesize, double? startdate, double? enddate)
        {
            Expressionable<Attendance> expressionable = new Expressionable<Attendance>();
            if (startdate != null && enddate != null)
            {


                DateTime startdateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                startdateTime = startdateTime.AddSeconds(startdate.Value).ToLocalTime();
                expressionable.And(a => a.AttendanceDate >= startdateTime);
                DateTime enddateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                enddateTime = enddateTime.AddSeconds(enddate.Value).ToLocalTime();
                expressionable.And(a => a.AttendanceDate <= enddateTime);
            }

            //HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //转换：automapper
            //1.安装程序集
            //2.配置映射关系
            //3.ioc配置注册关系生效
            //4.注入mapper，map映射
            PagingData<AttendanceWithUserName> pagelist = _attendanceService.QueryPageAttendanceWithUsername(expressionable.ToExpression(),pagesize,pageindex,a=>a.Id,true);
            //PagingData<SystemLogDto> result = _mapper.Map<PagingData<SystemLog>, PagingData<SystemLogDto>>(pagelist);
            //int totalcount = 0;
            //List<SystemLog> pagelist = _sqlSugarClient.Queryable<SystemLog>().ToPageList(pageindex, pagesize,ref totalcount);
            return new JsonResult(pagelist);
        }
    }
}