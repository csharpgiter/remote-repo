using Microsoft.AspNetCore.Mvc;

namespace SmartFactoryApi.Controllers
{
    /// <summary>
    /// ���Ĭ�ϵĿ�����
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _logger.LogInformation($"{this.GetType().FullName}������");
            _logger.LogWarning($"{this.GetType().FullName}������");
            _logger.LogError($"{this.GetType().FullName}������");
            _logger.LogDebug($"{this.GetType().FullName}������");
        }
        /// <summary>
        /// ���Ĭ�ϵ�api
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
