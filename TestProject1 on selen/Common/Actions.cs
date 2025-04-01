using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumExtras.WaitHelpers;
using System.Threading.Tasks;

namespace TestProject1_on_selen.Common
{
    public class Actions
    {
        private readonly IWebDriver driver;

        public Actions(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement FindElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var element = wait.Until(ExpectedConditions.ElementExists(locator));
            return element;

        }
        public void ClickOnElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            FindElement(locator).Click();

        }
        public void EnterText(By locator, string text)
        {
            FindElement(locator).Clear();
            FindElement(locator).SendKeys(text);
        }

        public bool IsElementVisible(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }

        }
        public void ScrollToElement(By locator)
        {
            IWebElement element = FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);
        }
    }
}
