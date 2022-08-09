using NUnit.Framework;
using Project_Brookes.appManager;

namespace Project_Brookes.Tests.ConfigurationFile
{
    public class TestBase
    {
        protected ApplicationManager App;

        [SetUp]
        public void SetupApplicationManager()
        {
            App = ApplicationManager.GetInstance();
        }

        [TearDown]
        public void TeardownTest()
        {
            //App.Driver.Quit();
        }
    }
}