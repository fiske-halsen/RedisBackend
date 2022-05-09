using Newtonsoft.Json;

namespace RedisAssignment.Model
{
    public class UniversityObj
    {
        //[JsonProperty(PropertyName = "ID IPEDS Occupation Parent")]
       // public string IDIPEDSOccupationParent { get; set; }
        //[JsonProperty("IPEDS Occupation Parent")]
        //public string IPEDSOccupationParent { get; set; }
        [JsonProperty("ID IPEDS Occupation")]
        public string IDIPEDSOccupation { get; set; }
        [JsonProperty("IPEDS Occupation")]
        public string IPEDSOccupation { get; set; }
        [JsonProperty("ID Year")]
        public int IDYear { get; set; }
        [JsonProperty("Year")]
        public string Year { get; set; }
        //[JsonProperty("ID Carnegie Parent")]
       // public string IDCarnegieParent { get; set; }
        //[JsonProperty("Carnegie Parent")]
        //public string CarnegieParent { get; set; }
        //[JsonProperty("ID Carnegie")]
       // public string IDCarnegie { get; set; }
        //[JsonProperty("Carnegie")]
       // public string Carnegie { get; set; }
       [JsonProperty("ID University")]
        public int IDUniversity { get; set; }
        [JsonProperty("University")]
        public string University { get; set; }
        [JsonProperty("Total Noninstructional Employees")]
        public string TotalNoninstructionalEmployees { get; set; }
        [JsonProperty("Slug University")]
        public string SlugUniversity { get; set; }
    }
}
