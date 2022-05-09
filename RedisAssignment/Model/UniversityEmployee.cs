using Newtonsoft.Json;

namespace RedisAssignment.Model
{
    public class UniversityEmployee
    {
        [JsonProperty("IPEDS Occupation")]
        public string IPEDSOccupation { get; set; }
        [JsonProperty("ID IPEDS Occupation")]
        public string IDIPEDSOccupation { get; set; }
        [JsonProperty("Total Noninstructional Employees")]
        public string TotalNoninstructionalEmployees { get; set; }



    }
}
