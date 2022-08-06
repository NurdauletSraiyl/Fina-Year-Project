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

    }
}