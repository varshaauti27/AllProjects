using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.BLL.Data
{
    public class GameManagerFactory
    {
        
        public static GameManager Create()
        {
            string chooserType = ConfigurationManager.AppSettings["Chooser"].ToString();

            if (chooserType == "Random")
                return new GameManager(new RandomChoice());
            else if (chooserType == "Static")
                return new GameManager(new StaticChoice());
            else
                throw new Exception("Chooser key in app.config not set properly!");
        }
        
    }
}
