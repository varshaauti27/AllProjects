using Ninject;
using SGBank.Data;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class DIContainer
    {
        public static IKernel Kernel = new StandardKernel();

        static DIContainer()
        {
            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            // Tell ninject that IAccountRepository should resolve to BasicAccountTestRepository
            if (mode == "BasicTest")
                Kernel.Bind<IAccountRepository>().To<BasicAccountTestRepository>();
            // Tell ninject that IAccountRepository should resolve to PrefersRockChoice
            else if (mode == "FreeTest")
                Kernel.Bind<IAccountRepository>().To<FreeAccountTestRepository>();
            else
                throw new Exception("Mode key in app.config not set properly!");
        }

    }
}
