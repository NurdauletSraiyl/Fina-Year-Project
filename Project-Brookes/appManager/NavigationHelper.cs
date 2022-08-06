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
            return this;
        }
    }
}