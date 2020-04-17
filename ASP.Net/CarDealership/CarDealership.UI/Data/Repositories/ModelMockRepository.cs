using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class ModelMockRepository : IModelRepository
    {
        private static readonly List<Model> _allModels = new List<Model>()
        {
            new Model{ Id =1, Name = "Civic", MakeId =1 ,MakeName="Honda", DateAdded = DateTime.Parse("2020-04-03"), UserId = "1"},
            new Model{ Id =2, Name = "Accord", MakeId=1, MakeName="Honda",DateAdded = DateTime.Parse("2020-04-03"), UserId = "2"},
            new Model{ Id =3, Name = "Corolla",MakeId=3, MakeName="Lexus", DateAdded = DateTime.Parse("2020-04-03"), UserId = "1"},
        };

        public void AddModel(Model model)
        {
            model.Id = _allModels.Max(i => i.Id) + 1;
            _allModels.Add(model);
        }

        public List<Model> GetAllModels()
        {
            return _allModels;
        }

        public Model GetModel(int modelId)
        {
            return _allModels.FirstOrDefault(c => c.Id == modelId);
        }

        public List<Model> GetModelsByMakeId(int makeId)
        {
            return _allModels.Where(i=>i.MakeId == makeId).ToList();
        }
    }
}