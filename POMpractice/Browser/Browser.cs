

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace POMpractice.Utilities
{
    public class Browser : IDisposable
    {
        //for normal execution
        //public IWebDriver driver;  
        public ThreadLocal<IWebDriver> driver = new();

        [SetUp]                          //for parallel exe driver to driver.Value
        public void WebBrowser()
        {
            //string browsername = ConfigurationManager.AppSettings["WebDriver"];


            InitBrowser("edge");

            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Navigate().GoToUrl("https://www.amazon.in/");
        }
        public IWebDriver getDriver()
        {
            return driver.Value;
        }
        public void InitBrowser(string browsername)
        {
            switch (browsername.ToLower())
            {
                case "chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;

                case "edge":

                    driver.Value = new EdgeDriver();
                    break;

            }
        }
        public static Jsonreader getdataparser()
        {
            return new Jsonreader();
        }
        [TearDown]
        public void Tear()
        {

            driver.Value.Quit();
            driver.Value.Dispose();
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            if (driver.IsValueCreated)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
            }
            driver.Dispose();
        }
    }
}
