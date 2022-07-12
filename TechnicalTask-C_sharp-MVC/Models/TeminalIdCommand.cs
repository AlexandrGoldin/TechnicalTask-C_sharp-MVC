using Newtonsoft.Json;

namespace TechnicalTask_C_sharp_MVC.Models
{
    public class TeminalIdCommand
    {
        [JsonProperty("item")]
        public Item Item { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
