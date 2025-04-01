using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1_on_selen.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1_on_selen.TestCases
{
    public class HomeTests
    {
        private IWebDriver driver;
        [SetUp]
        public void sETUP()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }
        [Test]
        public void SearchSamsungTv()
        {
            Homepage hp = new Homepage(driver);
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            Thread.Sleep(10);
            hp.Search("Samsung tv");
            Assert.IsTrue(driver.Title.Contains("Samsung tv"));
        }
        [TearDown]
        public void tEARDOWN()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
