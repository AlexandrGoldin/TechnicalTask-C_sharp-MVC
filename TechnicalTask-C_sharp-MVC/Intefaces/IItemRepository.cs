using System.Collections.Generic;
using TechnicalTask_C_sharp_MVC.MdelsDTO;

namespace TechnicalTask_C_sharp_MVC.Intefaces
{
    public interface IItemRepository
    {
        List<ItemDTO> GetItemList();
        void Create(ItemDTO itemDTO);

    }
}
