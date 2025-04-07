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
        public IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        public IWebDriver webDriver;

        
        //amzlogin
        /*[FindsBy(How = How.XPath, Using = "//span[text()='Hello, sign in']")]
        private IWebElement _loginbtn;*/
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

        // Buttons in Amazon Login Page 
        [FindsBy(How = How.Id, Using = "nav-logo-sprites")]
        private IWebElement AmazonPageRefreshbtn;
        [FindsBy(How = How.XPath, Using = "//input[@id='twotabsearchtextbox']")]
        private IWebElement SearchBox;
        [FindsBy(How = How.XPath, Using = "(//a[@role='button'])[1]")] 
        private IWebElement Deliverybtn;
        [FindsBy(How = How.XPath, Using = "//span[text()='Hello, sign in']")]
        private IWebElement _loginbtn;
        [FindsBy(How = How.XPath, Using = "//span[@class='icp-nav-link-inner']")]
        private IWebElement Languagebtn;
        [FindsBy(How = How.XPath, Using = "nav-orders")]
        private IWebElement Returnsordersbtnbtn;
        [FindsBy(How = How.XPath, Using = "//a[@class='f']")]
        private IWebElement CartSymbolbtn;
        [FindsBy(How = How.XPath, Using = "//a[text()='All'])[2]")]
        private IWebElement Allbtn;     //Freshbtn  - //ul[@class='nav-ul']//following::li[1]
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[1]")]
        private IWebElement Freshbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[2]")]
        private IWebElement MXPlayerbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[3]")]
        private IWebElement Sellbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[4]")]
        private IWebElement Bestsellersbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[5]")]
        private IWebElement Mobilesbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[6]")]
        private IWebElement Todaysdealsbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[7]")]
        private IWebElement Primebtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[8]")]
        private IWebElement CustomerServicesbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[9]")]
        private IWebElement NewReleasbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[10]")]
        private IWebElement Electronicsbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[11]")]
        private IWebElement Fashionbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[12]")]
        private IWebElement HomeandKitchenbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[13]")]
        private IWebElement AmazonPaybtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[14]")]
        private IWebElement Computersbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[15]")]
        private IWebElement Booksbtn;
        [FindsBy(How = How.XPath, Using = "//ul[@class='nav-ul']//following::li[16]")]
        private IWebElement CarsandMotorbikesbtn;




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
                
                IWebElement ValidPassword = driver.FindElement(By.XPath("//span[text()='Hello, Maharshi']"));
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

            var windowHandles = driver.WindowHandles;     // Handles switch Window
            driver.SwitchTo().Window(windowHandles[1]);

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
