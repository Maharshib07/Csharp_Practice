using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1_on_selen.Pages
{
    public class Homepage
    {
        private IWebDriver driver;
        [FindsBy(How = How.Name, Using = "field-keywords")]
        private IWebElement _searchTextbox;
        [FindsBy(How = How.Id, Using = "nav-search-submit-button")]
        private IWebElement _searchButton;
        [FindsBy(How = How.XPath, Using = "//div[@id='nav-link-accountList']")]
        private IWebElement _Loginlink;
        public Homepage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebDriver webDriver { get; private set; }

        public void homepages(IWebDriver dr)
        {
            driver = dr;
            PageFactory.InitElements(dr, this);
        }
        public void Search(string searchtext)
        {
            _searchTextbox.SendKeys(searchtext);
            _searchButton.Click();
            _Loginlink.Click();
        }
        
    }
}
