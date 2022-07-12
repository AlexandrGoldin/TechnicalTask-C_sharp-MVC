using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTask_C_sharp_MVC.MdelsDTO;

namespace TechnicalTask_C_sharp_MVC.Infrastucture
{
    public class DbInitializer
    {
        public static void Initialize(ItemDtoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Items.Any())
            {
                return;
            }

            var items = new ItemDTO[]
            {
            new ItemDTO{
                     Terminal_id= 129,
                     Command_id= 3,
                     Parameter1= 20000,
                     Parameter2= 0,
                     Parameter3= 0,
                     Parameter4= 0,
                     Str_parameter1= "Стартовый кредит",
                     State_name= "Нe отправлено",
                     Time_created= "1234:1234:1234",
                },
            new ItemDTO{
                     Terminal_id= 129,
                     Command_id= 2,
                     Parameter1= 20000,
                     Parameter2= 0,
                     Parameter3= 0,
                     Parameter4= 0,
                     Str_parameter1= "Перезагрузить терминал",
                     State_name= "Нe отправлено",
                     Time_created= "1234:1234:1234",
                },
            new ItemDTO{
                     Terminal_id= 129,
                     Command_id= 3,
                     Parameter1= 40000,
                     Parameter2= 0,
                     Parameter3= 0,
                     Parameter4= 0,
                     Str_parameter1= "Стартовый кредит",
                     State_name= "Нe отправлено",
                     Time_created= "1234:1234:1234",
                }
            };
            foreach (ItemDTO i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();
        }
    }   
}
