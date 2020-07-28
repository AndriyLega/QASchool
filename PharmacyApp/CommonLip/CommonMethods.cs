using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.CommonLip
{
    public class CommonMethods
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;
        private const int timeOut = 10;
        private ITakesScreenshot screenshotDriver;

        public CommonMethods(IWebDriver driver)
        {
            this.driver = driver;
            js = driver as IJavaScriptExecutor;
            screenshotDriver = driver as ITakesScreenshot;
        }


        /// <summary>
        /// Waiter with ExpectedCondition = ElementExists
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="maxTimeout"></param>
        /// <returns></returns>
        public IWebElement WaitForElementIsPresent(By locator, int maxTimeout = timeOut)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxTimeout)).Until(ExpectedConditions.ElementExists(locator));
        }

        /// <summary>
        /// Waiter with ExpectedCondition = ElementIsVisible
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="maxTimeout"></param>
        /// <returns></returns>
        public IWebElement WaitForElementIsVisable(IWebDriver driver, By locator, int maxsecond = timeOut)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxsecond)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Methid check if element present and returns true oe false
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public bool IsElementPresent(By locator)
        {
            try
            {
                WaitForElementIsPresent(locator);
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Method gets and returns web element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="message"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public IWebElement GetElementByWithLogs(IWebDriver driver, By by, string message, int second = timeOut)
        {
            IWebElement element = null;
            try
            {
                element = WaitForElementIsVisable(driver, by, second);
            }
            catch (WebDriverTimeoutException e)
            {
                LogUtil.WriteDebug("I've been waiting 10 seconds element but it is not visible");
                LogUtil.WriteDebug("**********************" + message + "********************** " + by);
                Assert.Fail(message);
            }
            return element;
        }

        #region Scrolls Methods

        public void HorizontalScrollToTheLastColumn()
        {
            js.ExecuteScript("document.querySelector('table th:last-child').scrollIntoView();");
            LogUtil.WriteDebug("Scrolled to the last column of the table");
        }

        public void ScrollToTheBottomOfThePage()
        {
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            LogUtil.WriteDebug("Scrolled to bottom of the page");
        }

        public void ScrollToTheElement(IWebElement element)
        {
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
            LogUtil.WriteDebug("Scrolled to the element " + element);
        }


        #endregion

        public enum SelectBy { Value, Text}
        public void SelectOptionInDropDownBy(SelectBy by, IWebElement dropDownElement, string value)
        {
            var selectElement = new SelectElement(dropDownElement);
            switch (by)
            {
                case SelectBy.Value:
                    {
                        //select by value
                        selectElement.SelectByValue(value);
                        break;
                    }

                case SelectBy.Text:
                    {
                        //select by value
                        selectElement.SelectByText(value);
                        break;
                    }
            }

        }

        /// <summary>
        /// Method take a screenshot of current opened page in browser
        /// </summary>
        public void TakeScreenshot()
        {
            string currentpath = TestContext.CurrentContext.TestDirectory;
            string[] pathList = currentpath.Split('\\');
            string sequence = @"\";
            string subPath = "Users/Andriy/Desktop/Screenshots";
            string path = pathList[0] + sequence + subPath + sequence;
            string timestamp = DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss");
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(path + timestamp + ".jpeg", ScreenshotImageFormat.Jpeg);
            LogUtil.WriteDebug("Please find more information on this screen: " + timestamp + ".jpeg");
        }
    }
}
