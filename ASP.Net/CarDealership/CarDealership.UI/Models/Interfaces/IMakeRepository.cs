﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.UI.Models.Interfaces
{
    public interface IMakeRepository
    {
        List<Make> GetAllMakes();
        Make GetMake(int id);
        void AddMake(Make make);
    }
}