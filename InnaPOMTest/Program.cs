using OpenQA.Selenium.Chrome;
using System;

namespace InnaPOMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChromeDriver chromeDriver = new ChromeDriver())
            {
                WorkUaSite site = new WorkUaSite(chromeDriver);
                site.CheckIsMenuExist();
                //site.CheckIsMenuCorrect();
                site.LoginEmpty();
                site.LoginIncorrect();
            }
            Console.ReadLine();
        }
    }
}
