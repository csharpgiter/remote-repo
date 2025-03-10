using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Zhaoxi.SmartFactory.Common.Result;

namespace SmartFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        [HttpGet("materialstatistic")]
        public async Task<IActionResult> GetStatistics()
        {
            ApiDataResult<object> apiDataResult= new ApiDataResult<object>()
            {
                Success = true,
                Message = "材料统计",
                Data = new {
                    title = "物料详情",
                    chartData = new int[] { 130, 220, 580, 480, 150, 340, 630, 390 },
                    chartxAxis = new string[] { "k924", "g002", "k878", "a55", "c635", "a557", "g078" },
                    color = "#2277ce",
                    chartType = "bar"
                },
                OValue = null
            };
            return await Task.FromResult(new JsonResult(apiDataResult));
        }

        [HttpGet("GoodStatistic")]
        public async Task<IActionResult> GetOutgood()
        {
            ApiDataResult<object> apiDataResult = new ApiDataResult<object>()
            {
                Success = true,
                Message = "出货统计",
                Data = new
                {
                   title = "产品出货-每天" ,
                   chartType = "line",
                   chartData = new int[] { 10, 20, 40, 30, 20, 50, 80, 10, 40, 30, 90 },
                   chartxAxis = new string[] { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00" },
                   color = "#71c24a"
                },
                OValue = null
            };
            return await Task.FromResult(new JsonResult(apiDataResult));
        }
    }
}


//------------笔记----------------//
////  public async Task<IActionResult> MyAction()
//{
//    // 创建一个 IActionResult 类型的结果
//    IActionResult result = Ok("操作成功");

//    // 使用 Task.FromResult 将结果封装成 Task<IActionResult>
//    Task<IActionResult> taskResult = Task.FromResult<IActionResult>(result);

//    // 等待任务完成（这里任务已经是完成状态）
//    IActionResult finalResult = await taskResult;

//    return finalResult;
//}