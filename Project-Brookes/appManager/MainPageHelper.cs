using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V102.Runtime;
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
        private By _showResults = By.XPath("//*[contains(normalize-space(text()),'Showing results')]");
        private By _courseSearchPage = By.XPath("//*[contains(normalize-space(text()),'Course search')]");
        private By _noResults = By.XPath("//*[contains(normalize-space(text()),'No results')]");
        private By _brookesLogo = By.ClassName("navbar-brand");
        
        private By _firstSearchResult = By.XPath("//*[@id='search-results']/li[2]/h3/a");

        private By _firstWord = By.XPath("//*[@id='search-results']/li[2]/h3/a/strong[1]");
        private By _secondWord = By.XPath("//*[@id='search-results']/li[2]/h3/a/strong[2]");
        
        private By _openDayButton = By.XPath("//*[contains(normalize-space(text()),'Attend an open day or webinar')]");
        private By _bookingPanel = By.XPath("//*[contains(normalize-space(text()),'Undergraduate (Oxford)')]");
        private By _bookingDate = By.XPath("//*[contains(normalize-space(text()),'Open Day: Saturday 08 October')]");
        
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
            try
            {
                Driver.FindElement(_acceptCookiesButtonLocator).Click();
            }
            catch (Exception e)
            {
            }
        }

        public bool resultsExist()
        {
            try
            {
                Driver.FindElement(_showResults);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool noResultsReturned()
        {
            try
            {
                Driver.FindElement(_noResults);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public bool SearchResults()
        {
            WaitLocator(_courseSearchPage);
            if (noResultsReturned())
            {
                Console.WriteLine("Search works correctly, but no results returned");
                return true;
            }
            else if (resultsExist())
            {
                Console.WriteLine("Search works correctly, results exists");
                return true;
            }
            else
            {
                Console.WriteLine("Search does not work");
                return false;
            }
        }

        public MainPageHelper returnMainPage()
        {
            Driver.FindElement(_brookesLogo).Click();
            return this;
        }

        public MainPageHelper similarityCheck(string course)
        {
            WaitLocator(_courseSearchPage);
            var words = course.Split(' ') ;
            var firstWord = words[0];
            var secondWord = words[1];
            string text1 = Driver.FindElement(_firstWord).Text;
            string text2 = Driver.FindElement(_secondWord).Text;
            
            
            if (text1 == firstWord && text2 == secondWord)
            {
                WaitLocator(_firstSearchResult);
                Driver.FindElement(_firstSearchResult).Click();
            }
            return this;
        }

        public MainPageHelper clickOpenDayButton()
        {
            var locator = Driver.FindElement(_openDayButton);
            Actions action = new Actions(Driver);
            action.MoveToElement(locator);
            action.Perform();
            WaitLocator(_openDayButton);
            Driver.FindElement(_openDayButton).Click();
            return this;
        }

        public bool AvailableDaysForBooking()
        {
            WaitElement(_bookingPanel);
            var locator = Driver.FindElement(_bookingPanel);
            Actions action = new Actions(Driver);
            action.MoveToElement(locator);
            action.Perform();

            string openDayDate = "Undergraduate Open Day: Saturday 08 October";
            string actualResult = Driver.FindElement(_bookingDate).Text;

            if (actualResult == openDayDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}