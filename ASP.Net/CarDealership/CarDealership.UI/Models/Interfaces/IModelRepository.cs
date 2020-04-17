using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.UI.Models.Interfaces
{
    public interface IModelRepository
    {
        List<Model> GetAllModels();

        List<Model> GetModelsByMakeId(int makeId);

        Model GetModel(int modelId);
        void AddModel(Model model);
    }
}
