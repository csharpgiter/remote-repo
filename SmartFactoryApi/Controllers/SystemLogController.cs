using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFactory.BusinessInterface;
using SmartFactory.Entity.EntityMap;
using SmartFactoryApi.Utility.Filter;
using SqlSugar;
using Zhaoxi.SmartFactory.Common.Result;

namespace SmartFactoryApi.Controllers
{
    /// <summary>
    /// 系统的日志管理
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SystemLogController : ControllerBase
    {
        private readonly ISqlSugarClient _sqlSugarClient;
        private readonly ILogger<SystemLogController> _logger;
        private readonly ISystemlogService _systemlogService;
        private readonly IMapper _mapper;
        public SystemLogController(ILogger<SystemLogController> logger, ISqlSugarClient sqlSugarClient,ISystemlogService systemlogService,IMapper mapper)
        {

            _logger = logger;
            _sqlSugarClient = sqlSugarClient;
            _systemlogService = systemlogService;
            _mapper = mapper;
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet("{pageindex:int}/{pagesize:int}/{startdate:double}/{enddate:double}")]
        [HttpGet("{pageindex:int}/{pagesize:int}")]
        //[CustomAlwaysOnResultFilter]

        public IActionResult SystemlogPage(int pageindex,int pagesize,double? startdate,double? enddate)
        {
            Expressionable<SystemLog> expressionable = new Expressionable<SystemLog>();
            if (startdate!= null && enddate != null)
            {
               
               
                DateTime startdateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                startdateTime= startdateTime.AddSeconds(startdate.Value).ToLocalTime();
                expressionable.And(x => x.Date >=startdateTime);
                DateTime enddateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                enddateTime = enddateTime.AddSeconds(enddate.Value).ToLocalTime();
                expressionable.And(x => x.Date <= enddateTime);
            }

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //转换：automapper
            //1.安装程序集
            //2.配置映射关系
            //3.ioc配置注册关系生效
            //4.注入mapper，map映射
            PagingData<SystemLog> pagelist= _systemlogService.QueryPage<SystemLog>(expressionable.ToExpression(), pagesize, pageindex, x => x.Id,true);
            PagingData<SystemLogDto> result = _mapper.Map<PagingData<SystemLog>,PagingData<SystemLogDto>>(pagelist);
            //int totalcount = 0;
            //List<SystemLog> pagelist = _sqlSugarClient.Queryable<SystemLog>().ToPageList(pageindex, pagesize,ref totalcount);
            return new JsonResult(result);
        }
    }
}
