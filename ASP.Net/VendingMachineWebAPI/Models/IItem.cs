using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineWebAPI.Models
{
    public interface IItem
    {
        List<Item> GetAll();
        Item GetItem(int itemId);
    }
}
