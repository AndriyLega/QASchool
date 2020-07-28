using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASchool.Selenium_Tests
{
    class FirstTestCases
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

        /// <summary>
        /// 1) Get title from opened tab
        /// 2) Print in consile "Hello world"
        /// 3) Print in console title of opened tab
        /// </summary>
        [Test, Order(2)]
        public void FirstTest()
        {
            string title = driver.Title;
            Console.WriteLine("Hello world");
            Console.WriteLine(title);
        }

        /// <summary>
        /// 1) Log in the system
        /// </summary>
        [Test, Order(1)]
        public void LogInTest()
        {
            LogIn();
        }

        /// <summary>
        /// 1) Log in the system
        /// 2) Navigate to http://fortesting.info/Account/Register
        /// 3) Go back to previouse page
        /// 4) Go forward
        /// 5) Refresh the page
        /// </summary>
        [Test, Order(3)]
        public void NavigationMethodsTest()
        {
            LogIn();
            driver.Navigate().GoToUrl("http://fortesting.info/Account/Register");
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();
        }

        /// <summary>
        /// Steps:
        /// 1) Fill in Email field
        /// 2) Fill in Password field
        /// 3) Click Login button
        /// </summary>
        private void LogIn()
        {
            driver.FindElement(By.Id("Email")).SendKeys("AutoQaschool@mailforspam.com");
            driver.FindElement(By.Id("Password")).SendKeys("!1234Qqwer");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
    }
}
