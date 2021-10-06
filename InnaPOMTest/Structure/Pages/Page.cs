using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnaPOMTest.Structure.Pages
{
    class Page
    {
        internal ChromeDriver ChromeDriver;
        internal ReadOnlyCollection<IWebElement> MenuItems { get; }

        public Page(ChromeDriver chromeDriver)
        {
            this.ChromeDriver = chromeDriver;
            this.MenuItems = this.ChromeDriver.FindElements(By.CssSelector(".navbar-default a"));
        }
    }
}
