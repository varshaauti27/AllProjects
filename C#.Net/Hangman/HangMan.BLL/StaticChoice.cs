using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.BLL
{
    public class StaticChoice : IChoiceGetter
    {
        public string GetChoice()
        {
            return "Word";
        }
    }
}