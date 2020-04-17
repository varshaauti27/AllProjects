using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class ModelViewModel
    {
        public Model Model { get; set; }

        public List<Model> ModelList { get; set; }

        public List<SelectListItem> MakeItems { get; set; }

        public ModelViewModel()
        {
            Model = new Model();
            ModelList = new List<Model>();
            MakeItems = new List<SelectListItem>();
        }
        public void SetMakeItems(IEnumerable<Make> makes)
        {
            foreach (var make in makes)
            {
                MakeItems.Add(new SelectListItem()
                {
                    Value = make.Id.ToString(),
                    Text = make.Name
                });
            }
        }
    }
}