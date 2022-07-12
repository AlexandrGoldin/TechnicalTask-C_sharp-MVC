using System.ComponentModel.DataAnnotations;

namespace TechnicalTask_C_sharp_MVC.MdelsDTO
{
    public class ItemDTO
    {
        [Key]
        public int Id { get; set; }

        public int Terminal_id { get; set; }

        public int Command_id { get; set; }

        public int? Parameter1 { get; set; }

        public int? Parameter2 { get; set; }

        public int? Parameter3 { get; set; }

        public int? Parameter4 { get; set; }

        public string Str_parameter1 { get; set; }

        public string State_name { get; set; }

        public string Time_created { get; set; }


    }
}
