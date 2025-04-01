using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1_on_selen.Pages
{
    class Loginpage
    {
        IWebDriver _webdriver;
        

        public void Amazonlogin(IWebDriver webdriver)
        {
            _webdriver = webdriver;

        }
    }
}
