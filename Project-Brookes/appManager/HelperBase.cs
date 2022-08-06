using System;
using System.Threading;
using OpenQA.Selenium;

namespace Project_Brookes.appManager
{
    public class HelperBase
    {
        protected IWebDriver Driver;
        public ApplicationManager Manager;

        public HelperBase(ApplicationManager manager)
        {
            Manager = manager;
            Driver = manager.Driver;
        }

        public void InspectionUrl(string url, string message)
        {
            Console.Out.WriteLine(Driver.Url == url ?
                message : "Navigation error {0}", url);
        }

        public bool InspectationPage(string url)
        {
            return (Driver.Url == url);
        }

        public void WaitElement(By locator)
        {
            int i = 0;
            int count = 60;
            int timeout = 500;
            while (Driver.FindElements(locator).Count == 0 && (i < count))
            {
                Thread.Sleep(timeout);
                i++;
            }

            if (i == count)
            {
                Console.WriteLine("Element with such locator {0}, did not found", locator);
            }
        }
        
        public void Type(IWebElement element, string text)
        {
            if (text != null)
            {
                element.Clear();
                element.SendKeys(text);
            }
        }
    }
}