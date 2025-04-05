using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POMpractice.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMpractice.PageObject
{
    public class LoginPage
    {
        public IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);

        }
        public IWebDriver webDriver;

        
        //amzlogin
        [FindsBy(How = How.XPath, Using = "//span[text()='Hello, sign in']")]
        private IWebElement _loginbtn;
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement enterusername;
        [FindsBy(How = How.XPath, Using = "//input[@class='a-button-input']")]
        private IWebElement usernamecontinue;
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement enterpassword;
        [FindsBy(How = How.XPath, Using = "//input[@id='signInSubmit']")]
        private IWebElement Signbtn;
        [FindsBy(How = How.LinkText, Using = "Hello, Maharshi")]
        private IWebElement VerifySign;

        //select a sony tv into cart
        [FindsBy(How = How.XPath, Using = "//input[@id='twotabsearchtextbox']")]
        private IWebElement entersonytv;  //sendkeys and sendkeys(keys.enter)
        [FindsBy(How = How.XPath, Using = "//span[text()='Sony 139 cm (55 inches) BRAVIA 2 4K Ultra HD Smart LED Google TV K-55S25B (Black)']")]
        private IWebElement Findsony55inchtv;

        [FindsBy(How = How.XPath, Using = "(//input[@name='submit.add-to-cart'])[2]")]
        private IWebElement addtvtocart;
        [FindsBy(How = How.XPath, Using = "//input[@aria-labelledby='attach-sidesheet-view-cart-button-announce']")]
        private IWebElement clickoncartbtn;
        [FindsBy(How = How.Name, Using = "proceedToRetailCheckout")]
        private IWebElement proceedtobuy;
        [FindsBy(How = How.XPath, Using = "(//input[@type='radio'])[4]")]
        private IWebElement clickonUPIradiobtn;
        [FindsBy(How = How.Name, Using = "__sif_encryptedVPA_collect")]
        private IWebElement enterUPIId;    //SendKeys("8897251375@ybl");
        [FindsBy(How = How.Name, Using = "ppw-widgetEvent:ValidateUpiIdEvent")]
        private IWebElement verifyUPIId;
        [FindsBy(How = How.XPath, Using = "//input[@aria-labelledby='checkout-secondary-continue-button-id-announce']")]
        private IWebElement clickonusethispayment;
       
       
        public void LogintoAmazon(string username, string password)
        {
            try
            {
                _loginbtn.Click();

                enterusername.SendKeys(username);
                usernamecontinue.Click();
                enterpassword.SendKeys(password);
                Signbtn.Click();
                
                IWebElement ValidPassword = _driver.FindElement(By.XPath("//span[text()='Hello, Maharshi']"));
                string stitle = ValidPassword.Text;
                Assert.IsTrue(stitle == "Hello, Maharshi", "Invalid Username or Password");
            }
            catch (Exception msg)
            {
                Console.WriteLine("Invalid Login  :" + msg.Message);

            }
        }
        public void SearchTv(string tvname,string upiid)
        {
            entersonytv.SendKeys(tvname);
            entersonytv.SendKeys(Keys.Enter);
            Findsony55inchtv.Click();

            var windowHandles = _driver.WindowHandles;     // Handles switch Window
            _driver.SwitchTo().Window(windowHandles[1]);

            addtvtocart.Click();
            clickoncartbtn.Click();
            proceedtobuy.Click();
            clickonUPIradiobtn.Click();
            enterUPIId.SendKeys(upiid);
            verifyUPIId.Click();
            clickonusethispayment.Click();
       }   
    }
}
