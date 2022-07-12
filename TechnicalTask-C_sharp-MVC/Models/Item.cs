using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TechnicalTask_C_sharp_MVC.Models
{
    public class Item
    {
        [JsonProperty("terminal_id")]
        public int Terminal_id { get; set; }

        [JsonProperty("command_id")]
        public int Command_id { get; set; }

        [JsonProperty("parameter1")]
        public int? Parameter1 { get; set; }

        [JsonProperty("parameter2")]
        public int? Parameter2 { get; set; }

        [JsonProperty("parameter3")]
        public int? Parameter3 { get; set; }

        [JsonProperty("parameter4")]
        public int? Parameter4 { get; set; }

        [JsonProperty("str_parameter1")]
        public string Str_parameter1 { get; set; }

        [JsonProperty("str_parameter2")]
        public string Str_parameter2 { get; set; }

        [JsonProperty("state")]
        public int? State { get; set; }

        [JsonProperty("state_name")]
        public string State_name { get; set; }

        [JsonProperty("time_created")]
        public string Time_created { get; set; }

        [JsonProperty("time_delivered")]
        public object Time_delivered { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }
    }
}

