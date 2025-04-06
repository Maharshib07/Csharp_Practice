using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMpractice.Common
{
    public class Actions
    {
        public IWebDriver driver;
        public Actions(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebElement FindElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementExists(locator));
            return element;

        }
        public void ClickonElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            FindElement(locator).Click();
            element.Click();
        }
        public void EnterText(By locator, string text)
        {
            FindElement(locator).Clear();
            FindElement(locator).SendKeys(text);
        }
        public void ScrollToElement(By locator)
        {
            IWebElement element = FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);
        }
        //public void scrolltoelement(By locator)
        //{

        //    FindElement(locator).SendKeys(Keys.PageDown);
        //    //FindElement(locator).ScrollToElement();   
        //    locator.Click();
        //}
        //public void Doubleclick(By locator)
        //{

        //    FindElement(locator).DoubleClick()
        //}
    }
}
