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

namespace POMpractice.Testcasess
{
    public class BaseTest : Browser
    //dotnet test path.csproj --filter "TestCategory=Smoke"
    {

        [Test]
        //[TestCase("maharshibadiganti@gmail.com","Maharshi08@#")]
        //[TestCase("Maharshibadiganti@gmail.com","Maharshi")]
        [TestCaseSource(nameof(AddTestData))]
        
        public void AmazonLogin(string username, string password)//str name str password
        {
            LoginPage login = new LoginPage(getDriver());
            login.LogintoAmazon(username, password);
            //login.WaitUntillPageDisplay("");
            //LoginPage success = login.LogintoAmazon(username, password);
            // success.WaitUntillPageDisplay();

        }
        [Test]
        public void selectATvtocart()
        {
            LoginPage chTv = new LoginPage(getDriver());
            chTv.SearchTv("sony bravia 55 inch", "8889725137@ybl");

        }
        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData("maharshibadiganti@gmail.com", "Maharshi08@#");
            yield return new TestCaseData("Maharshibadiganti@gmail.com", "Maharshi");
        }
        public static IEnumerable<TestCaseData> AddTestData()
        {
            yield return new TestCaseData(getdataparser().ExtractData("username"), getdataparser().ExtractData("password"));
            yield return new TestCaseData(getdataparser().ExtractData("username_invalid"), getdataparser().ExtractData("password_invalid"));
        }
        public void WaitUntillPageDisplay(string Path)
        {
            WebDriverWait wait = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(Path)));
        }

        // for parallel execution 1.test method 2.methods in class 3.Test file


        [Test, TestCaseSource(nameof(AddTestData))]
        [Parallelizable(ParallelScope.All)]
        public void AmazonLogin1(string username, string password)//str name str password
        {
            LoginPage login = new LoginPage(getDriver());
            login.LogintoAmazon(username, password);
            //login.WaitUntillPageDisplay("");
            //LoginPage success = login.LogintoAmazon(username, password);
            // success.WaitUntillPageDisplay();

        }

    }
}
