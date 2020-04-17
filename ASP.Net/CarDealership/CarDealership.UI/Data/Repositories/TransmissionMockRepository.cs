using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class TransmissionMockRepository : ITransmissionRepository
    {
        private static readonly List<Transmission> _allTransmission = new List<Transmission>()
        {
            new Transmission{ Id = 1 , Description = "Automatic"},
            new Transmission{ Id = 2,Description = "Manual"}
        };
        public List<Transmission> GetAllTransmissions()
        {
            return _allTransmission;
        }

        public Transmission GetTransmission(int id)
        {
            return _allTransmission.FirstOrDefault(i => i.Id == id);
        }
    }
}