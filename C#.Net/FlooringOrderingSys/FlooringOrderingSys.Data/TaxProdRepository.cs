using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Data
{
    public class TaxProdRepository : ITaxRepository
    {
        private string _filePath;

        public TaxProdRepository(string path)
        {
            this._filePath = path;
        }

        public bool AddTax(Tax tax)
        {
            try
            {
                List<Tax> taxes;
                taxes = LoadTaxes();

                if (taxes == null)
                {
                    taxes = new List<Tax>();
                }
                taxes.Add(tax);
                SaveTaxesToFile(_filePath, taxes);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void SaveTaxesToFile(string filePath, List<Tax> taxes)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine("StateAbbreviation,StateName,TaxRate");
                foreach (Tax t in taxes)
                {
                    writer.WriteLine(MapTaxToLine(t));
                }
            }
        }

        private string MapTaxToLine(Tax t)
        {
            return t.StateAbbreviation + "," + t.StateName + "," + t.TaxRate;
        }

        public List<Tax> LoadTaxes()
        {
            List<Tax> taxes = new List<Tax>();
            if (File.Exists(_filePath))
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    reader.ReadLine();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] prop = line.Split(',');
                        taxes.Add(new Tax { StateAbbreviation = prop[0], StateName = prop[1], TaxRate = decimal.Parse(prop[2]) });
                    }
                }
            }
            return taxes;
        }

        public Tax GetTax(string stateAbbreviation)
        {
            List<Tax> all = LoadTaxes();

            if (all != null)
                return all.Where(i => i.StateAbbreviation == stateAbbreviation).FirstOrDefault();
            return null;
        }

        public bool EditTax(Tax newTax)
        {
            try
            {
                List<Tax> all = LoadTaxes();

                int index = all.FindIndex(i => i.StateAbbreviation == newTax.StateAbbreviation);
                if (index != -1)
                {
                    all[index] = newTax;
                }
                SaveTaxesToFile(_filePath, all);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool RemoveTax(string stateAbbreviation)
        {
            try
            {
                List<Tax> all = LoadTaxes();

                int index = all.FindIndex(i => i.StateAbbreviation == stateAbbreviation);
                all.RemoveAt(index);

                SaveTaxesToFile(_filePath, all);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
