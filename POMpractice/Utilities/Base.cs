using getting_started_with_CSharp.Drivers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace POMpractice.Utilities
{
    public class Base //: IDisposable 
    {
        //for normal execution
        public IWebDriver driver;
        //public ThreadLocal<IWebDriver> driver = new();

        [SetUp]                          //for parallel exe driver to driver
        public void WebBrowser()
        {
            //string browsername = ConfigurationManager.AppSettings["WebDriver"];


            InitBrowser("edge");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.in/");
        }
        public IWebDriver getDriver()
        {
            return driver;
        }
        public void InitBrowser(string browsername)
        {
            switch (browsername.ToLower())
            {
                case "chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "edge":

                    driver = new EdgeDriver();
                    break;

            }
        }
        public static Jsonreader getdataparser()
        {
            return new Jsonreader();
        }
        public void Screenshots(string filename)
        {
           Screenshot takesScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = $"C:\\ScreenshotsSelenium\\{filename}.png";
            //Screenshot screenshot = driver.GetScreenshot();
            byte[] img = Convert.FromBase64String(takesScreenshot.AsBase64EncodedString);

            System.IO.File.WriteAllBytes(path, img);
            Console.WriteLine($"Screenshot saved to: {path}");

        }
        [TearDown]
        public void Tear()
        {

            driver.Quit();
            driver.Dispose();
        }

        //[OneTimeTearDown]
        //public void Dispose()  //parallel Exe
        //{
        //    if (driver.IsValueCreated)
        //    {
        //        driver.Quit();
        //        driver.Dispose();
        //    }

        //    driver.Dispose();
        //}
    }

}

