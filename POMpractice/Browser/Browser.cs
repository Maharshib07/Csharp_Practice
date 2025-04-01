using getting_started_with_CSharp.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace POMpractice.Utilities
{
    public class Browser
    {

        public IWebDriver driver;
        [SetUp]
        public void WebBrowser()
        {
            InitBrowser("Edge");

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
        [TearDown]
        public void Tear()
        {
            Thread.Sleep(3000);
            driver.Quit();
            driver.Dispose();


        }
    }
}
