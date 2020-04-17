﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.UI.Models.Interfaces
{
    public interface IStateRepository
    {
        List<State> GetAllStates();

        State GetState(int stateId);
    }
}
