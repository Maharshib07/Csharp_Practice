using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using POMpractice.Utilities;
using POMpractice.PageObject;

namespace POMpractice.Testcases
{
    public class BaseTest : Browser
    {
        [Test]
        public void AmazonLogin()
        {
            LoginPage login = new LoginPage(getDriver());
            login.validLoginbtn("maharshibadiganti@gmail.com", "Maharshi08@#"); 
        }
        [Test]
        public void selectSonyTv()
        {
            LoginPage chTv = new LoginPage(getDriver());
            chTv.SearchTv("sony bravia 55 inch","hsyyg558");
            var windowHandles = driver.WindowHandles;             // Handles switch Window
            driver.SwitchTo().Window(windowHandles[1]);
            Console.WriteLine("");
        }
    }
}
