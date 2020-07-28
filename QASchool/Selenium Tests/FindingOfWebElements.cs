using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASchool.SeleniumTests
{
    class FindingOfWebElements
    {
        private IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Url = "http://fortesting.info/";
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Test]
        public void FindingElements()
        {
            GoToRegisterPage();
            var emailField = driver.FindElement(By.CssSelector("#Email"));
            var passwordField = driver.FindElement(By.Name("Password"));
            var title = driver.FindElement(By.TagName("h4"));
            var logInLink = driver.FindElement(By.LinkText("Log in"));

            emailField.SendKeys("Element was found");
            passwordField.SendKeys("Element was found");
            string textOfTitle = title.Text;
            logInLink.Click();

            var registerLink = driver.FindElement(By.PartialLinkText("Regis"));
            registerLink.Click();
        }

        /// <summary>
        /// Steps:
        /// 1) Fill in Email field
        /// 2) Fill in Password field
        /// 3) Click Login button
        /// </summary>
        private void GoToRegisterPage()
        {
            driver.FindElement(By.Id("Email")).SendKeys("AutoQaschool@mailforspam.com");
            driver.FindElement(By.Id("Password")).SendKeys("!1234Qqwer");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            driver.Navigate().GoToUrl("http://fortesting.info/Account/Register");
        }

        [Test]

        public void FindElementsDifference()
        {
            GoToRegisterPage();
            ChaeckIfCheckBoxSelected();

            //var incorrectElement = driver.FindElement(By.CssSelector(".noelement"));
            //var incorrectElem = driver.FindElements(By.CssSelector(".noelement"));
            //int countOfFoundElements = incorrectElem.Count; 

            var singlElement = driver.FindElement(By.XPath("//input[@id='Email']"));
            //var listOfOneFoundElement = driver.FindElements(By.CssSelector("#Email"));
            //singlElement.SendKeys("Email");
            //listOfOneFoundElement[0].SendKeys("Email");

            var firstFoundElement = driver.FindElement(By.CssSelector(".form-control"));
            var allFoundElement = driver.FindElements(By.CssSelector(".form-control"));

            firstFoundElement.SendKeys("Email");

            var emailField = allFoundElement[0];
            emailField.Clear();
            emailField.SendKeys("Email2");

            allFoundElement[1].SendKeys("Password");
            allFoundElement[2].SendKeys("Confirm Password");
            allFoundElement[3].SendKeys("FirstName");

        }
        /// <summary>
        /// Method ticks 'Is Admin' checkbox if it was not checked
        /// </summary>
        private void ChaeckIfCheckBoxSelected()
        {
            var isAdminCheckbox = driver.FindElement(By.XPath("//input[@id='IsAdmin']"));
            bool isCheckboxSelected = isAdminCheckbox.Selected;
            if (!isCheckboxSelected)
            {
                isAdminCheckbox.Click();
            }
        }
    }
}

