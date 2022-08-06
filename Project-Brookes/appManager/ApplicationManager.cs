using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Project_Brookes.appManager
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        protected NavigationHelper navigator;
        protected MainPageHelper mainPage;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = ConfigHelper.GetValue<string>("baseUrl");
            navigator = new NavigationHelper(this, baseURL);
            mainPage = new MainPageHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenMainPage();
                app.Value = newInstance;
            }

            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public NavigationHelper Navigator
        {
            get { return navigator; }
        }

        public MainPageHelper MainPage
        {
            get { return mainPage; }
        }
    }
}