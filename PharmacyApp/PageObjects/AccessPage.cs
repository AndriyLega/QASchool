using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.PageObjects
{
    public class AccessPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        private IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//input[@id='Email']")]
        private IWebElement EmailField;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement LogInButton;

        public AccessPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Method clicks on 'Log In' button on LogIn page
        /// </summary>
        private void ClickOnLogInButton()
        {
            LogInButton.Click();
        }

        /// <summary>
        /// Method fills in 'Email' field
        /// </summary>
        private void FillInEmailField(string emailValue)
        {
            EmailField.SendKeys(emailValue);
        }

        /// <summary>
        /// Method fills in 'Password' field
        /// </summary>
        private void FillInPasswordField(string paswordValue)
        {
            PasswordField.SendKeys(paswordValue);
        }

        /// <summary>
        /// Steps:
        /// 1) Fill in Email field
        /// 2) Fill in Password field
        /// 3) Click Login button
        /// </summary>
        public void AcseesToWebSite()
        {
            FillInEmailField("AutoQaschool@mailforspam.com");
            FillInPasswordField("!1234Qqwer");
            ClickOnLogInButton();
        }
    }
}
