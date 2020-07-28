using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PharmacyApp.CommonLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        private IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//input[@id='Email']")]
        private IWebElement EmailField;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement LogInButton;

        [FindsBy(How = How.XPath, Using = "//span[@data-valmsg-for='Password']")]
        private IWebElement WarningMessagePasswordField;

        [FindsBy(How = How.XPath, Using = "//span[@data-valmsg-for='Email']")]
        private IWebElement WarningMessageEmailField;

        [FindsBy(How = How.XPath, Using = "//div[@class='validation-summary-errors text-danger']//li")]
        private IWebElement WarningMessageOfIncorrectPassword;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Method clicks on 'Log In' button on LogIn page
        /// </summary>
        public void ClickOnLogInButton()
        {
            LogInButton.Click();
            LogUtil.WriteDebug("Clicked on Login button");
        }

        /// <summary>
        /// Method fills in 'Email' field
        /// </summary>
        public void FillInEmailField(string emailValue)
        {
            EmailField.SendKeys(emailValue);
            LogUtil.WriteDebug("Filled in email field with data:" + emailValue);
        }
    
        /// <summary>
        /// Method fills in 'Password' field
        /// </summary>
        public void FillInPasswordField(string paswordValue)
        {
            PasswordField.SendKeys(paswordValue);
            LogUtil.WriteDebug("Filled in password field with data:" + paswordValue);
        }

        /// <summary>
        /// Method gets text from warning message for Email field and returns this vakue
        /// </summary>
        public string GetTextFromWarningMessageEmailField()
        {
            LogUtil.WriteDebug("Getting text from warning message of Email field");
            return WarningMessageEmailField.Text;
        }

        /// <summary>
        /// Method gets text from warning message for Password field and returns this vakue
        /// </summary>
        public string GetTextFromWarningMessagePasswordField()
        {
            LogUtil.WriteDebug("Getting text from warning message of Password field");
            return WarningMessagePasswordField.Text;
        }

        /// <summary>
        /// Method gets text from warning message about incorrect Password and returns this vakue
        /// </summary>
        public string GetTextFromWarningMessageOfIncorrectPassword()
        {
            LogUtil.WriteDebug("Getting text from warning message of incorrect creds");
            return WarningMessageOfIncorrectPassword.Text;
        }
    }
}
