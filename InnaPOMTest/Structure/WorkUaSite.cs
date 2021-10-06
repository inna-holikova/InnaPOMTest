using InnaPOMTest.Structure;
using InnaPOMTest.Structure.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnaPOMTest
{
    class WorkUaSite
    {
        public string Url { get { return "https://www.work.ua/ru/"; } }
        private List<Page> _pages { get; set; }
        Page _activePage;
        ChromeDriver chromeDriver = new ChromeDriver(); 

        public WorkUaSite(ChromeDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }

        public void CheckIsMenuExist()
        {
            chromeDriver.Url = this.Url;
            _activePage = new Home(chromeDriver);
            if (_activePage.MenuItems.Count != 5)
            {
                throw new ApplicationException("Menu items are not equal to 5!");
            }
            else
            {
                List<string> menus = new List<string>() { "Work.ua", "Найти вакансии", "Разместить резюме", "Войти" };
                var menuDict = _activePage.MenuItems.ToDictionary(el => el.Text);
                foreach (var menu in menus)
                {
                    if (!menuDict.ContainsKey(menu))
                    {
                        throw new ApplicationException($"Menu item '{menu}' does not exist!");
                    }
                }
                Console.WriteLine("Test: Menu test has been completed. ");
            }
        }

        // !!! НЕ НАХОДИТ главную страницу Work.ua почему-то и выбрасывает ошибку
        // поэтому не вызывала эту функцию в Program.cs

        public void CheckIsMenuCorrect()
        {
            chromeDriver.Url = this.Url;
            _activePage = new Home(chromeDriver);
            for (int i = 0; i < _activePage.MenuItems.Count; i++)
            {
                var item = _activePage.MenuItems[i];
                string menuText = item.Text;
                item.Click();
                _activePage = PageFactory.CreatePageInstance(menuText, chromeDriver);
                if (_activePage == null)
                {
                    throw new ApplicationException($"Page '{menuText}' does not exist!");
                }
            }
            Console.WriteLine("Test: Pages are equal to menu items");
        }
        public void LoginEmpty()
        {
            chromeDriver.Url = this.Url;
            _activePage = new Home(chromeDriver);
            IWebElement loginBtn = chromeDriver.FindElementById("loginIcon");
            loginBtn.Click();
            IWebElement email = chromeDriver.FindElementById("user-login");
            email.SendKeys(" ");
            email.Submit();
            IWebElement error = chromeDriver.FindElementById("user-login-error");
            if (error == null)
            {
                Console.WriteLine("The error message about an empty field is missing!");
            }
            else 
            {
                Console.WriteLine("Test: The error of an empty field has been processed successfully.");
            }
        }

        public void LoginIncorrect()
        {
            chromeDriver.Url = this.Url;
            _activePage = new Home(chromeDriver);
            IWebElement loginBtn = chromeDriver.FindElementById("loginIcon");
            loginBtn.Click();
            IWebElement email = chromeDriver.FindElementById("user-login");
            email.SendKeys("123h");
            email.Submit();
            IWebElement error = chromeDriver.FindElementById("user-login-error");
            if (error == null)
            {
                Console.WriteLine("The error message about an incorrect login is missing!");
            }
            else
            {
                Console.WriteLine("Test: The error of an incorrect login has been processed successfully.");
            }
            Console.ReadLine();
        }
    }
}
