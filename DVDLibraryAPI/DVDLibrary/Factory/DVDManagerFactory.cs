using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DVDLibrary.Models;

namespace DVDLibrary.Factory
{
    public class DVDManagerFactory {
        public static IDVDRepository GetRepository()
        {
            string appSetting = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (appSetting)
            {
                case "Mock":
                    return new DVDRepositoryMock();
                case "ADO":
                    return new DVDRepositoryADO();
            }
            throw new Exception("Not using Mock or ADO in the Web.Config!");
        }
    }
}