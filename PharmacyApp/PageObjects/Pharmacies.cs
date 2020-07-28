using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PharmacyApp.CommonLip;
using PharmacyApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PharmacyApp.CommonLip.CommonMethods;

namespace PharmacyApp.PageObjects
{
    public class Pharmacies
    {
        private IWebDriver driver;
        private CommonMethods commonMethods;

        #region Pharmacy DropDown
        private const string xpathPharmacyDropDown = "//a[contains(text(),'Pharmacy')and @class='dropdown-toggle']";
        private readonly By PahrmacyDropdownLocator = By.XPath(xpathPharmacyDropDown);

        private const string xpathAddPharmacyOption = "//a[@href='/Pharmacy/Create']";
        private readonly By AddPharmacyOptionLocator = By.XPath(xpathAddPharmacyOption);

        private const string xpathManagePharmaciesOption = "//a[@href='/Pharmacy']";
        private readonly By ManagePharmaciesOptionLocator = By.XPath(xpathManagePharmaciesOption);
        #endregion

        #region Pharmacies Page

        private const string xpathPharmaciesTitle = "//h4[text()='Pharmacies']";
        private readonly By PharmaciesTitleLocator = By.XPath(xpathPharmaciesTitle);

        private const string xpathPhone2Column = "//th[contains(text(),'Phone2')]";
        private readonly By Phone2ColumnLocator = By.XPath(xpathPhone2Column);

        private const string xpathManageButton = "//a[text()='Manage']";
        private readonly By ManageButtonLocator = By.XPath(xpathManageButton);

        private const string xpathListOfRowInTable = "//table/tbody//tr";
        private readonly By ListOfRowInTableLocator = By.XPath(xpathListOfRowInTable);

        #endregion

        #region Managers page

        private const string xpathListOfManagerTableRows = "//div[@id='managers']//tr";
        private readonly By ListOfManagerTableRowsLocator = By.XPath(xpathListOfManagerTableRows);

        private const string xpathManagersBadge = "//a[@href='#managers']//span[@class='badge']";
        private readonly By ManagersBadgeLocator = By.XPath(xpathManagersBadge);

        private const string xpathManagersTableEmailColumn = "//div[@id='managers']//tbody//tr//td[1]";
        private readonly By ManagersTableEmailColumnLocator = By.XPath(xpathManagersTableEmailColumn);
        
        #endregion

        public Pharmacies(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
        }

        /// <summary>
        /// Methods clicks on option: 'Add Pharmacy' and 'Manag Pahrmacies' in Pharmacy dropdown
        /// </summary>
        public void SelectPahrmacyOption(PharmacyDropDownOptions options)
        {
            commonMethods.GetElementByWithLogs(driver, PahrmacyDropdownLocator, "Can NOT click on pharmacy dropDown").Click();
            LogUtil.WriteDebug("click on pharmacy dropDown");
            switch (options)
            {
                case PharmacyDropDownOptions.AddPharmacy:
                    {
                        commonMethods.GetElementByWithLogs(driver, AddPharmacyOptionLocator, "Can NOT click on 'Add Pharmacy' option").Click();
                        LogUtil.WriteDebug("Clicked on Add Pharmacy option");
                        break;
                    }

                case PharmacyDropDownOptions.ManagePahrmacies:
                    {
                        commonMethods.GetElementByWithLogs(driver, ManagePharmaciesOptionLocator, "Can NOT click on 'Manag Pahrmacies' option").Click();
                        LogUtil.WriteDebug("Clicked on Manag Pahrmacies option");
                        break;
                    }
            }
            commonMethods.WaitForElementIsVisable(driver, PharmaciesTitleLocator);
        }

        public void ScrollToTheColumn(string columnname)
        {
            commonMethods.ScrollToTheElement(commonMethods.GetElementByWithLogs(driver, By.XPath("//th[contains(text(),'" + columnname + "')]"), "Can NOT find " + columnname + " column"));
            LogUtil.WriteDebug("Scrolled to the Photo Column");
        }

        public void ClickOnManageButton(string pharmacyname)
        {
            commonMethods.GetElementByWithLogs(driver, By.XPath("//td[contains(text(),'" + pharmacyname +"')]/ancestor::tr"+ xpathManageButton), "Can NOT click Manage button").Click();
            LogUtil.WriteDebug("click on Manage button");
        }

        public void ScrollToTheRow(int rownumber)
        {
            commonMethods.ScrollToTheElement(commonMethods.GetElementByWithLogs(driver, By.XPath(xpathListOfRowInTable + "[" + rownumber + "]"), "Can NOT Find " + rownumber +" row"));
            LogUtil.WriteDebug("Scrolled to the " + rownumber + "row");
        }

        public void SelectOptionInPharmacyUserDropDown(string value)
        {
            var dropDown = commonMethods.GetElementByWithLogs(driver, By.XPath("//select[@id='Id']"), "Can NOT find Pharmasy USer dropdown");
            commonMethods.SelectOptionInDropDownBy(SelectBy.Value, dropDown, value);
            LogUtil.WriteDebug("Selected option by " + value + "in Pharmacy User dropdown");
        }

        public int CountOfTableRows()
        {
            int rows = driver.FindElements(ListOfManagerTableRowsLocator).Count()-1;
            LogUtil.WriteDebug("Count of rows in the Manager tabel is=" + rows);
            return rows;
        }

        public string GetManagersBadge()
        {
            string badge = commonMethods.GetElementByWithLogs(driver, ManagersBadgeLocator, "Can NOT find managers badge").Text;
            LogUtil.WriteDebug("Count of managers =" + badge);
            return badge;
        }

        public List<string> GetAllManagers()
        {
            List<string> allManagers = new List<string>();
            var emails = driver.FindElements(ManagersTableEmailColumnLocator);
            for (int k = 0; k < emails.Count; k++)
            {
                //string emailText = emails[k].Text;
                //allManagers.Add(emailText);
                allManagers.Add(emails[k].Text);

            }
            return allManagers;
        }
    }
}
