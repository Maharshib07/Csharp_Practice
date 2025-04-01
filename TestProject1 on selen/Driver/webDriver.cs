using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace getting_started_with_CSharp.Drivers
{
    public class WebDriverManager
    {
        private static List<IWebDriver> activeDrivers = new List<IWebDriver>();

        // This method will return a new driver instance
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver = InitializeDriver(browser);
            activeDrivers.Add(driver);
            return driver;
        }

         // Initialize the WebDriver based on the browser
        private static IWebDriver InitializeDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new ArgumentException("Unsupported browser: " + browser);
            }
        }

        // Method to quit all active drivers
        public static void QuitAllDrivers()
        {
            foreach (var driver in activeDrivers)
            {
                try
                {
                    driver.Quit();
                    driver.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error quitting driver: {ex.Message}");
                }
            }
            activeDrivers.Clear();
        }
    }
}
