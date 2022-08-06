using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Project_Brookes.appManager
{
    public class NavigationHelper : HelperBase
    {
        private readonly string _baseUrl;

        public NavigationHelper(ApplicationManager manager, string baseUrl) : base(manager)
        {
            _baseUrl = baseUrl;
        }

        public NavigationHelper OpenMainPage()
        {
            Driver.Navigate().GoToUrl(_baseUrl);
            InspectationPage(_baseUrl);
            return this;
        }

        public NavigationHelper WaitAddress(string address)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url.ToLowerInvariant().Equals(address));
            return this;
        }
        public string ExpectedURL(string address)
        {
            string urlAddress = _baseUrl + ConfigHelper.GetValue<string>(address);
            return urlAddress;
        }
    }
}