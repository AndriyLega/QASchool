using NUnit.Framework;
using OpenQA.Selenium;
using PharmacyApp.Enums;
using PharmacyApp.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.UITests
{
    public class PharmaciesTests:BaseTest
    {
        private Pharmacies pharmacies; 

        [SetUp]
        public void SetUp()
        {
            pharmacies = new Pharmacies(driver);
            //logInPage.FillInEmailField(loginModel.ValidEmail);
            //logInPage.FillInPasswordField(loginModel.ValidPassword);
            //logInPage.ClickOnLogInButton();
            //homePage.WaitUntilHomePageAppears();
        }

        [Test, Order(1)]
        public void CheckIfEmailFieldIsRequired()
        {
            pharmacies.SelectPahrmacyOption(PharmacyDropDownOptions.ManagePahrmacies);
            List<string> allEmails = pharmacies.GetAllManagers();
            //commonMethods.HorizontalScrollToTheLastColumn();
            //commonMethods.ScrollToTheBottomOfThePage();
            //pharmacies.ScrollToTheColumn("Phone2");
            //pharmacies.ScrollToTheRow(15);
            //pharmacies.ClickOnManageButton("1Cent1");
            //pharmacies.SelectOptionInPharmacyUserDropDown("021a2f11-209a-4fc5-9278-37b54f2f281b");
            //int countBefore = pharmacies.CountOfTableRows();
            int badgeBefore = Int32.Parse(pharmacies.GetManagersBadge());
            ////Steps to add new manager
            //int countAfter = pharmacies.CountOfTableRows();
            //int badgeAfter = Int32.Parse(pharmacies.GetManagersBadge());
            //Assert.IsTrue(countBefore.Equals(countAfter - 1), "Expected count of rows after adding " + (countBefore + 1) + ".  Actualresult: " + countAfter);
            //Assert.IsTrue(countBefore.Equals(badgeAfter - 1), "Expected count of rows after adding " + (badgeBefore + 1) + ".  Actualresult: " + badgeAfter);
        }

        [Test, Order(1)]
        public void CheckPharmacy()
        {
            //int countBefor = dataBaseMethods.GetCountOfPharmacies();
            ////steps to add new pharmacy
            //int countAfter = dataBaseMethods.GetCountOfPharmacies();
            //string nameOfPharmacy = dataBaseMethods.GetNameOfLastAddedPharmacy();
            SortedDictionary<string, string> namesAndDescriptions = dataBaseMethods.GetPharmaciesNameAndDescription();
        }


    }
}
