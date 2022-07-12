using Newtonsoft.Json;
using System.Collections.Generic;

namespace TechnicalTask_C_sharp_MVC.Models
{
    public class DbCommandTypesBaseQueryResult
    {
        [JsonProperty("page_number")]
        public int Page_number { get; set; }

        [JsonProperty("items_per_page")]
        public int Items_per_page { get; set; }

        [JsonProperty("items_count")]
        public int Items_count { get; set; }

        [JsonProperty("items")]
        public List<DbCommandTypes> Items { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
