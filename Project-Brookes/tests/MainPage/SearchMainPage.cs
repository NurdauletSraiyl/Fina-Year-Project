using NUnit.Framework;
using Project_Brookes.Tests.ConfigurationFile;

namespace Project_Brookes.Tests
{
    [TestFixture]
    public class SearchMainPage : TestBase
    {
        [SetUp]
        public void Precondition()
        {
            App.MainPage.CookiesAcceptance();
        }
        
        [Test]
        [Author("Nurdaulet Sraiyl")]
        [Description("MainPage_01")]
        public void id01_SearchHappyPath()
        {
            App.MainPage.SearchBoxClick();
            App.MainPage.SearchBoxSendKey("Computer Science");
            App.MainPage.SearchButtonClick();
            Assert.IsTrue(App.MainPage.SearchResults(),"Test failed");
        }
        
        [Test]
        [Author("Nurdaulet Sraiyl")]
        [Description("MainPage_02")]
        [TestCase("Mechanical Engineering")]
        [TestCase("Medicine")]
        [TestCase("qwerty")]
        [TestCase("1232451")]
        [TestCase("!@#$%^&")]
        public void id02_SearchTestCases(string searchText)
        {
            App.MainPage.SearchBoxClick();
            App.MainPage.SearchBoxSendKey(searchText);
            App.MainPage.SearchButtonClick();
            Assert.IsTrue(App.MainPage.SearchResults(),"Test failed");
        }

        [Test]
        [Author("Nurdaulet Sraiyl")]
        [Description("MainPage_03")]
        [TestCase("Computer Science")]
        [TestCase("Mechanical Engineering")]
        [TestCase("Software Engineering")]
        public void d03_bookingOpenDay(string searchText)
        {
            App.MainPage.SearchBoxClick();
            App.MainPage.SearchBoxSendKey(searchText);
            App.MainPage.SearchButtonClick();
            App.MainPage.similarityCheck(searchText);
            App.MainPage.clickOpenDayButton();
            Assert.IsTrue(App.MainPage.AvailableDaysForBooking(),"Test failed");
        }
        

        [TearDown]
        public void Postcondition()
        {
            //App.MainPage.returnMainPage();
            App.Navigator.OpenMainPage();
        }
    }
}