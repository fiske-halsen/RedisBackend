using Newtonsoft.Json;

namespace RedisAssignment.Model
{
    public class Wage
    {
        [JsonProperty("ID Detailed Occupation")]
        public int IDDetailedOccupation { get; set; }
    }

    public class WageData
    {
        public List<Wage> data { get; set; }
    }

}
