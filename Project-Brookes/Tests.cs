using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace Project_Brookes
{
    [TestFixture]
    public class AuthorizationTestTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor) driver;
            vars = new Dictionary<string, object>();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void authorizationTest()
        {
            driver.Navigate().GoToUrl("https://www.brookes.ac.uk/");
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
            driver.FindElement(By.LinkText("Students")).Click();
            {
                var element = driver.FindElement(By.LinkText("Students"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.Id("quicklinks-item1")).Click();
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys("17010029");
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys("441814Nurik!");
            driver.FindElement(By.Name("_eventId_proceed")).Click();
            Thread.Sleep(8000);
            driver.FindElement(By.Id("user")).Click();
            driver.FindElement(By.Id("signOut")).Click();
            driver.Close();
        }
    }
}