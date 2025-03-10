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
    public class UserLogController : ControllerBase
    {
        private readonly ISqlSugarClient _sqlSugarClient;
        private readonly ILogger<UserLogController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserService _UserService;
        public UserLogController(ILogger<UserLogController> logger, ISqlSugarClient sqlSugarClient,IMapper mapper,IUserService userService)
        {

            _logger = logger;
            _sqlSugarClient = sqlSugarClient;
            _UserService = userService;
            _mapper = mapper;
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet("{pageindex:int}/{pagesize:int}/{keywords}")]
        [HttpGet("{pageindex:int}/{pagesize:int}")]
        //[CustomAlwaysOnResultFilter]
        public IActionResult UserLogPage(int pageindex,int pagesize,string? keywords)
        {
            Expressionable<User> expressionable = new Expressionable<User>();
            if (!string.IsNullOrWhiteSpace(keywords))
            {
                expressionable.And(x => x.UserName.Contains(keywords));
            }

            //HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //转换：automapper
            //1.安装程序集
            //2.配置映射关系
            //3.ioc配置注册关系生效
            //4.注入mapper，map映射
            PagingData<User> pagelist= _UserService.QueryPage<User>(expressionable.ToExpression(), pagesize, pageindex, x => x.Id,true);
            PagingData<UserDto> result = _mapper.Map<PagingData<User>,PagingData<UserDto>>(pagelist);
            //int totalcount = 0;
            //List<UserLog> pagelist = _sqlSugarClient.Queryable<UserLog>().ToPageList(pageindex, pagesize,ref totalcount);
            return new JsonResult(result);
        }
    }
}
