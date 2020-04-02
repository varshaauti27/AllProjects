using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineWebAPI.Models
{
    public class ItemRepository 
    {
        public static List<Item> _allItem = new List<Item>()
        {
            new Item { ItemId = 1 ,Name = "Apples", Price=1.00M, Quantity=12},
            new Item { ItemId = 2, Name = "Snikers", Price = 1.99M, Quantity = 14 },
            new Item { ItemId = 3, Name = "Bags", Price = 2.99M, Quantity = 10 },
            new Item { ItemId = 4, Name = "Kit-Kat", Price = 0.99M, Quantity = 20 },
            new Item { ItemId = 5, Name = "Banana", Price = 0.99M, Quantity = 0 }
        };

        public static List<Item> GetAll()
        {
            return _allItem;
        }

        public static Item GetItem(int itemId)
        {
            return _allItem.FirstOrDefault(i => i.ItemId == itemId);
        }
    }
}