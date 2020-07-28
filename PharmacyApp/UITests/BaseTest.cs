using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PharmacyApp.CommonLip;
using PharmacyApp.DataBase;
using PharmacyApp.Models;
using PharmacyApp.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.UITests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        private AccessPage accessPage;
        protected LoginPage logInPage;
        protected CommonMethods commonMethods;
        protected HomePage homePage;
        protected LoginPageModel loginModel;
        protected DataBaseMethods dataBaseMethods;
        private string pathLog = string.Format("{0}{1}{2}{3}{4}", "PharmacyApp", DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, ".log");

        [SetUp]
        protected void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://fortesting.info/";

            logInPage = new LoginPage(driver);
            commonMethods = new CommonMethods(driver);
            accessPage = new AccessPage(driver);
            homePage = new HomePage(driver);
            dataBaseMethods = new DataBaseMethods();
            accessPage.AcseesToWebSite();
            LogUtil.WriteDebug("Opened Chrome browser");
            LogUtil.WriteDebug("Navigating to http://fortesting.info/");
            LogUtil.WriteDebug("**********Starting execution a new test**********");
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            LogUtil.CreateLogFile("CommonLogAppender", pathLog);
            loginModel = JsonDeserealization.GetJsonResult<LoginPageModel>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JsonConfigs/LoginJsonFile.json"));
            LogUtil.WriteDebug("Read all data from Json file LoginJsonFile.json");
        }


        [TearDown]
        protected void CloseBrowser()
        {
            var result = TestContext.CurrentContext.Result;
            if (result.Outcome.Status.Equals(TestStatus.Failed))
            {
                commonMethods.TakeScreenshot();
                LogUtil.WriteDebug(result.Message);
            }
            driver.Quit();
            LogUtil.WriteDebug("Close Chrome browser");
        }
    }
}
