using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Project_Brookes.appManager
{
    public class MainPageHelper : HelperBase
    {
        private By _mainpageContainerLocator = By.ClassName("container");
        
        private By _searchBoxLocator = By.ClassName("sr-only");
        
        
        public MainPageHelper(ApplicationManager manager) : base(manager)
        {
        }

        public IWebElement BrookesLogo()
        {
            WaitElement(_mainpageContainerLocator);
            return Driver.FindElement(_mainpageContainerLocator);
        }

        public IWebElement SearchBox()
        {
            IsLocatorDisplayed(_searchBoxLocator);
            return Driver.FindElement((_searchBoxLocator));
        }

        public MainPageHelper SearchBoxClick()
        {
            IsLocatorDisplayed(_searchBoxLocator);
            ClickElement(_searchBoxLocator);
            return this;
        }

        public bool IsLocatorDisplayed(By locator)
        {
            try
            {
                return WaitLocator(locator).Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IWebElement WaitLocator(By expectedValue)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(expectedValue));
            return Driver.FindElement(expectedValue);
        }

        public MainPageHelper ClickElement(By locator)
        {
            var element = Driver.FindElement(locator);
            element.Click();
            return this;
        }
    }
}