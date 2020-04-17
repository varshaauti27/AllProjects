using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class StateMockRepository : IStateRepository
    {
        private static readonly List<State> _allStates = new List<State>()
        {
            new State{ Id = 1 , Name = "Alaska", Code="AK" },
            new State{ Id = 2 , Name = "Arizona", Code="AZ" },
            new State{ Id = 3 , Name = "Arkansas", Code="AR" },
            new State{ Id = 4 , Name = "California", Code="CA" },
            new State{ Id = 5 , Name = "Colorado", Code="CO" },
            new State{ Id = 6 , Name = "Florida", Code="FL" },
        };

        public List<State> GetAllStates()
        {
            return _allStates;
        }

        public State GetState(int stateId)
        {
            return _allStates.FirstOrDefault(c => c.Id == stateId);
        }
    }
}