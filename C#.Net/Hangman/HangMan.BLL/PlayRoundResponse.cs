using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.BLL
{
    public class PlayRoundResponse
    {
        public List<char> Guess { get; set; }
        public List<char> Miss { get; set; }

        public char[] UpdatedString { get; set; }
        public GameResult Result { get; set; }
    }
}