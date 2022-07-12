using Newtonsoft.Json;

namespace TechnicalTask_C_sharp_MVC.Models
{
    public class DbCommandTypes
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parameter_name1")]
        public string Parameter_name1 { get; set; }

        [JsonProperty("parameter_name2")]
        public string Parameter_name2 { get; set; }

        [JsonProperty("parameter_name3")]
        public string Parameter_name3 { get; set; }

        [JsonProperty("parameter_name4")]
        public string Parameter_name4 { get; set; }

        [JsonProperty("str_parameter_name1")]
        public string Str_parameter_name1 { get; set; }

        [JsonProperty("str_parameter_name2")]
        public string Str_parameter_name2 { get; set; }

        [JsonProperty("parameter_default_value1")]
        public int? Parameter_default_value1 { get; set; }

        [JsonProperty("parameter_default_value2")]
        public int? Parameter_default_value2 { get; set; }

        [JsonProperty("parameter_default_value3")]
        public int? Parameter_default_value3 { get; set; }

        [JsonProperty("parameter_default_value4")]
        public int? Parameter_default_value4 { get; set; }

        [JsonProperty("str_parameter_default_value1")]
        public string Str_parameter_default_value1 { get; set; }

        [JsonProperty("str_parameter_default_value2")]
        public string Str_parameter_default_value2 { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }
    }
}
