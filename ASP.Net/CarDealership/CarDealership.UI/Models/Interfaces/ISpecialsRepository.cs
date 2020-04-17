using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.UI.Models.Interfaces
{
    public interface ISpecialsRepository 
    {
        List<Specials> GetAllSpecials();

        void DeleteSpecial(int id);

        void AddSpecial(Specials specials);
    }
}
