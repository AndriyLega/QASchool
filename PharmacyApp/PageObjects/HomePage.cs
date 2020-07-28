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
    public class HomePage
    {
        private IWebDriver driver;
        private CommonMethods commonMethods;

        private const string XpathLogOutLink = "//a[text()='Log out']";
        [FindsBy(How = How.XPath, Using = XpathLogOutLink)]
        private IWebElement LogOutLink;

        [FindsBy(How = How.XPath, Using = "//h5")]
        private IWebElement SuccessMessage;

        private const string XpathUserLink = "//a[text()='lega1@mailinator.com']";
        [FindsBy(How = How.XPath, Using = XpathUserLink)]
        private IWebElement UserLink;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Method WAITS UNTIL logIn page appears (commit)
        /// </summary>
        public void WaitUntilHomePageAppears()
        {
            commonMethods.WaitForElementIsPresent(By.XPath(XpathLogOutLink));
            LogUtil.WriteDebug("Waiting till Home page open");
        }

        /// <summary>
        /// Method gets text from success message after login and returns this vakue
        /// </summary>
        public string GetTextFromSuccessMessage()
        {
            LogUtil.WriteDebug("Getting text about success login");
            return SuccessMessage.GetAttribute("innerText");
        }

        /// <summary>
        /// Method gets text from success message after login and returns this vakue
        /// </summary>
        public bool IsEmailLinkPresent()
        {
            LogUtil.WriteDebug("Check if element present");
            return commonMethods.IsElementPresent(By.XPath(XpathUserLink));
        }
    }
}
