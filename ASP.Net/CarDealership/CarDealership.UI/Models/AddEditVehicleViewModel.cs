using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddEditVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }

        public int? TypeId { get; set; }

        public List<SelectListItem> MakeItems { get; set; }
        public List<SelectListItem> ModelItems { get; set; }
        public List<SelectListItem> TypeItems { get; set; }
        public List<SelectListItem> BodyStyleItems { get; set; }
        public List<SelectListItem> TransmissionItems { get; set; }
        public List<SelectListItem> ColorItems { get; set; }

        public AddEditVehicleViewModel()
        {
            Vehicle = new Vehicle();
            MakeItems = new List<SelectListItem>();
            ModelItems = new List<SelectListItem>();
            TypeItems = new List<SelectListItem>();
            BodyStyleItems = new List<SelectListItem>();
            TransmissionItems = new List<SelectListItem>();
            ColorItems = new List<SelectListItem>();

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

        public void SetModelItems(IEnumerable<Model> models)
        {
            foreach (var model in models)
            {
                ModelItems.Add(new SelectListItem()
                {
                    Value = model.Id.ToString(),
                    Text = model.Name
                });
            }
        }

        public void SetTypeItems()
        {
            TypeItems.Add(new SelectListItem() { Value = "1", Text = "New"});
            TypeItems.Add(new SelectListItem() { Value = "2", Text = "Used" });
        }

        public void SetBodyStyleItems(IEnumerable<Style> styles)
        {
            foreach (var style in styles)
            {
                BodyStyleItems.Add(new SelectListItem()
                {
                    Value = style.Id.ToString(),
                    Text = style.Description
                });
            }
        }

        public void SetTransmissionItems(IEnumerable<Transmission> transmissions)
        {
            foreach (var t in transmissions)
            {
                TransmissionItems.Add(new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = t.Description
                });
            }
            //TransmissionItems.Add(new SelectListItem() { Value = "1", Text = "Automatic"});
            //TransmissionItems.Add(new SelectListItem() { Value = "2", Text = "Manual" });
        }

        public void SetColorItems(IEnumerable<Color> colors)
        {
            //ColorItems.Add(new SelectListItem() { Value = "1", Text = "Black", Selected = true });
            //ColorItems.Add(new SelectListItem() { Value = "2", Text = "White" });
            //ColorItems.Add(new SelectListItem() { Value = "3", Text = "Gray" });
            //ColorItems.Add(new SelectListItem() { Value = "4", Text = "Red" });
            //ColorItems.Add(new SelectListItem() { Value = "5", Text = "Silver" });
            //ColorItems.Add(new SelectListItem() { Value = "6", Text = "Blue" });

            foreach (var color in colors)
            {
                ColorItems.Add(new SelectListItem()
                {
                    Value = color.Id.ToString(),
                    Text = color.Name
                });
            }
        }
    }
}