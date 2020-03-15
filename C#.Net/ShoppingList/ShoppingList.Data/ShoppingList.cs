using ShoppingList.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Data
{
    public class ShoppingList
    {
        readonly Dictionary<int, Item> allItems = new Dictionary<int, Item>();
        readonly string Path = "ShoppingList.txt";
        int _nextItemID = 0;
        public ShoppingList()
        {
            if (File.Exists(Path))      //GetAll data from file add asign it to allItems.....
            {
                List<Item> data = ReadAllShoppingList();
                foreach (Item i in data)
                {
                    allItems.Add(i.ID, i);
                    _nextItemID = i.ID;
                }
            }
            _nextItemID = _nextItemID + 1;
        }

        public Item SearchByName(string name)
        {
            return allItems.Values.FirstOrDefault(item => item.Name.ToUpper().Trim().Equals(name));
        }

        public void EditItem(int id,int quantity)
        {
            allItems[id].Quantity = quantity;
            WriteAllItemsToFile(allItems);
        }

        public void DeleteAll()
        {
            allItems.Clear();
            _nextItemID = 1;
            WriteAllItemsToFile(allItems);
        }

        public Item SearchById(int id)
        {
            return allItems.Values.FirstOrDefault(item => item.ID == id);
        }

        public bool RemoveById(int id)
        {
            return allItems.Remove(id);
        }

        public bool IsItemFound(int id)
        {
            return allItems.ContainsKey(id);
        }

        public int AddItem(string name, int quantity)
        {
            allItems.Add(_nextItemID, new Item(_nextItemID,name, quantity));
            WriteAllItemsToFile(allItems);
            int index = _nextItemID;
            _nextItemID++;
            return index;
        }

        private void WriteAllItemsToFile(Dictionary<int, Item> allItems)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path))
                {
                    foreach (var item in allItems)
                    {
                        writer.WriteLine(MapItemToLine(item.Value));
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                allItems = new Dictionary<int, Item>();
            }
            finally
            {
            
            }

        }

        private string MapItemToLine(Item value)
        {
            return value.ID + " | " + value.Name + " | " + value.Quantity;
        }

        private List<Item> ReadAllShoppingList()
        {
            List<Item> shoppingItems = new List<Item>();

            try
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        shoppingItems.Add(MapLineToItem(line));
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                shoppingItems = new List<Item>();
            }
            finally
            {
                
            }
            return shoppingItems;
        }

        private Item MapLineToItem(string line)
        {
            string[] props = line.Split('|');
            Item item = new Item(int.Parse(props[0]),props[1],int.Parse(props[2]));
            return item;
        }

        public List<Item> GetList()
        {
            List<Item> data = new List<Item>();
            foreach (var item in allItems)
            {
                data.Add(item.Value);
            }
            return data;
        }
    }
}
