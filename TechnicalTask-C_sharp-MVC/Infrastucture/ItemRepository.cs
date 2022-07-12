using System.Collections.Generic;
using System.Linq;
using TechnicalTask_C_sharp_MVC.Intefaces;
using TechnicalTask_C_sharp_MVC.MdelsDTO;

namespace TechnicalTask_C_sharp_MVC.Infrastucture
{
    public class ItemRepository : IItemRepository
    {
        private ItemDtoContext _itemDtoContext;
        public ItemRepository(ItemDtoContext itemDtoContext)
        {
            _itemDtoContext = itemDtoContext;
        }
                   
        public List<ItemDTO> GetItemList()
        {
            var itemList=_itemDtoContext.Items.ToList();

            var orderedItem = itemList.OrderByDescending(i => i.Id);

            var itemRes = orderedItem.Take(6);

            // get six item values

            return itemRes.ToList();
        }

        public void Create(ItemDTO itemDTO)
        {
            _itemDtoContext.Items.Add(itemDTO);
            _itemDtoContext.SaveChanges();

        }
    }
}
