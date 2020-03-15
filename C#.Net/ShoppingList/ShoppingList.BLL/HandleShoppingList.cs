using ShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.BLL
{
    public class HandleShoppingList
    {
        ShoppingList.Data.ShoppingList shopListData = new ShoppingList.Data.ShoppingList();

        public List<Item> GetShoppingList()
        {
            return shopListData.GetList();
        }

        public string AddItemToShoppingList(string name, int quantity)
        {
            int index = shopListData.AddItem(name,quantity);
            return $" Item {name} Added Successfully with Id : {index}";
        }

        public bool IsListContainsItem(int id)
        {
            return shopListData.IsItemFound(id);
        }

        public bool RemoveItemById(int id)
        {
            return shopListData.RemoveById(id);
        }

        public Item SearchItemsById(int id)
        {
            return shopListData.SearchById(id);
        }

        public Item SearchItemByName(string name)
        {
            return shopListData.SearchByName(name);
        }

        public void DeleteAllList()
        {
            shopListData.DeleteAll();
        }

        public void EditShoppingItem(int id,int q)
        {
            shopListData.EditItem(id,q);
        }
    }
}
