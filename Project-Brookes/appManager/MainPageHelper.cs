using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Project_Brookes.appManager
{
    public class MainPageHelper : HelperBase
    {
        private By _mainpageContainerLocator = By.ClassName("container");

        private By _cookiesPanelLocator = By.ClassName("ot-sdk-container");
        private By _acceptCookiesButtonLocator = By.ClassName("accept-btn-container");

        private By _searchBoxLocator = By.XPath
            ("//input[@name='ctl00$ctl00$ContentPlaceHolder1$HomepageBannerPlaceHolder$homepagecoursesearch$CourseSearchTerm']");
        private By _searchButtonLocator = By.XPath
            ("//input[@name='ctl00$ctl00$ContentPlaceHolder1$HomepageBannerPlaceHolder$homepagecoursesearch$BtnGo']");
        private By _firstAttributeSearch = By.XPath("//*[contains(normalize-space(text()),'Showing results')]");
        
        
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
            //var locator = Driver.FindElement(By.ClassName("btn-block"));
            //Actions action = new Actions(Driver);
            IsLocatorDisplayed(_searchBoxLocator);
            //action.MoveToElement(locator);
            //action.Perform();
            
            ClickElement(_searchBoxLocator);
            return this;
        }

        public MainPageHelper SearchBoxSendKey(string text)
        {
            Driver.FindElement(_searchBoxLocator).SendKeys(text);
            return this;
        }

        public MainPageHelper SearchButtonClick()
        {
            Driver.FindElement(_searchButtonLocator).Click();
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

        public void CookiesAcceptance()
        {
            if (IsLocatorDisplayed(_cookiesPanelLocator))
            {
                Driver.FindElement(_acceptCookiesButtonLocator).Click();
            }
        }
        
        public bool SearchResults()
        {
            WaitLocator(_firstAttributeSearch);
            return true;
        }
    }
}