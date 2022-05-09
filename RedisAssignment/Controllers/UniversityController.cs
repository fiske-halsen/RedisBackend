using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedisAssignment.HttpUtils;
using RedisAssignment.Model;

namespace RedisAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly ILogger<UniversityController> _logger;

        public UniversityController(ILogger<UniversityController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<UniversityData> Get()
        {
            return await GetOrSetCache<UniversityData>("university", DateTime.UtcNow.AddMinutes(60));
        }
        [HttpGet("Hanzoooo/{occupation}")]
        public async Task<string> RedisHashSetTest(string occupation)
        {
            return await GetOrSetCacheHashSet("university", occupation);
        }
        public async Task<string> GetOrSetCacheHashSet(string key, string occupation)
        {
            var redisConnection = RedisConnector.Connector.Connection.GetDatabase();
            var value = redisConnection.HashGet(key, occupation);
            if (!value.IsNull)
            {
                return value;
            } else
            {
                var client = ApiClientInitializer.GetClient();
                var list = await ApiClientInitializer.Get<UniversityEmployeeData>(client);

                var element = list.data.Where(i => i.IPEDSOccupation.Equals(occupation)).FirstOrDefault();

                if (element == null)
                {
                    throw new Exception("Not a valid occupation");
                }

                redisConnection.HashSet(key, occupation, element.TotalNoninstructionalEmployees);
                return element.TotalNoninstructionalEmployees;
            }
        }

        public async Task<T> GetOrSetCache<T>(string key, DateTime expires)
        {
            var expiryTimeSpan = expires.Subtract(DateTime.UtcNow);
            var redisConnection = RedisConnector.Connector.Connection.GetDatabase();
            var value = redisConnection.StringGet(key);
            if (!value.IsNull)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            else
            {
                var client = ApiClientInitializer.GetClient();
                var text = await ApiClientInitializer.Get<T>(client);

                redisConnection.StringSet(key, JsonConvert.SerializeObject(text), expiryTimeSpan);
                return text;
            }
        }
    }
}