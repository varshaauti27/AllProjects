using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Model
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Item(int id, string name, int quantity)
        {
            ID = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
