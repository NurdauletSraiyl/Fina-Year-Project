using NUnit.Framework;
using Project_Brookes.Tests.ConfigurationFile;

namespace Project_Brookes.Tests
{
    [TestFixture]
    public class SearchMainPage : TestBase
    {
        [Test]
        [Author("Nurdaulet Sraiyl")]
        [Description("MainPage_01")]
        public void id01_SearchHappyPath()
        {
            App.MainPage.SearchBoxClick();
            
        }

    }
}