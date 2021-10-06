using InnaPOMTest.Structure.Pages;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnaPOMTest.Structure
{
    class PageFactory
    {
        public static Page CreatePageInstance(string menuName, ChromeDriver chromeDriver)
        {
            switch (menuName)
            {
                case "Home": return new Home(chromeDriver);
                case "FindJob": return new FindJob(chromeDriver);
                case "PutCV": return new PutCV(chromeDriver);
                case "Login": return new Login(chromeDriver);
            }
            return null;
        }
    }
}
