using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PharmacyApp.CommonLip;
using PharmacyApp.Models;
using PharmacyApp.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PharmacyApp.UITests
{
    public class LoginPageTests:BaseTest
    {

        [Test, Order(1), Category("Perfomance"), Category("Regression")]
        public void CheckIfEmailFieldIsRequired()
        {
            logInPage.FillInPasswordField(loginModel.ValidPassword);
            logInPage.ClickOnLogInButton();
            string warningMessageEmailField = logInPage.GetTextFromWarningMessageEmailField();
            Assert.IsTrue(warningMessageEmailField.Equals(loginModel.EmptyEmailWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageEmailField + "  Expected result: " + loginModel.EmptyEmailWarningMessage);
        }

        [Test, Order(2), Description("Assembly description here"), Category("API"), Category("Regression"), Ignore("UI changes. We have ti fix this method")]
        public void CheckIfPasswordFieldIsRequired()
        {
            logInPage.FillInEmailField(loginModel.ValidEmail);
            logInPage.ClickOnLogInButton();
            string warningMessagePasswordField = logInPage.GetTextFromWarningMessagePasswordField();
            Assert.IsTrue(warningMessagePasswordField.Equals(loginModel.EmptyPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessagePasswordField + "  Expected result: " + loginModel.EmptyPasswordWarningMessage);
        }

        [Test, Order(3)]
        [TestCase("@gmail.com")]
        [TestCase("test@gmail.")]
        [TestCase("test@gmailcom")]
        [TestCase("testgmail.com")]
        public void ValidationOfInvalidEmail(string invaildEmail)
        {
            logInPage.FillInEmailField(invaildEmail);
            logInPage.FillInPasswordField(loginModel.ValidPassword);
            logInPage.ClickOnLogInButton(); 
            string warningMessageEmailField = logInPage.GetTextFromWarningMessageEmailField();
            Assert.IsTrue(warningMessageEmailField.Equals(loginModel.InvalidEmailWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageEmailField + "  Expected result: " + loginModel.InvalidEmailWarningMessage);
        }

        [Test, Order(4)]
        public void ValidationOfInvalidPassword()
        {
            logInPage.FillInEmailField(loginModel.ValidEmail);
            logInPage.FillInPasswordField(loginModel.InvalidPassword);
            logInPage.ClickOnLogInButton();
            string warningMessageOfIncorrectPassword = logInPage.GetTextFromWarningMessageOfIncorrectPassword();
            Assert.IsTrue(warningMessageOfIncorrectPassword.Equals(loginModel.IncorrectPasswordWarningMessage), "Warning message is NOT correct. Actual result: "
                + warningMessageOfIncorrectPassword + "  Expected result: " + loginModel.IncorrectPasswordWarningMessage);
        }

        [Test, Order(5)]
        public void CheckSuccessfulLogIn()
        {
            logInPage.FillInEmailField(loginModel.ValidEmail);
            logInPage.FillInPasswordField(loginModel.ValidPassword);
            logInPage.ClickOnLogInButton();
            homePage.WaitUntilHomePageAppears();
            string successMessage = homePage.GetTextFromSuccessMessage();
            bool isEmailLinkPresent = homePage.IsEmailLinkPresent();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(successMessage.Equals(loginModel.SuccessfulLogInMessage), "Warning message is NOT correct. Actual result: " + successMessage + "  Expected result: " + loginModel.SuccessfulLogInMessage);
                Assert.IsTrue(isEmailLinkPresent, "Link 'lega1@mailinator.com' is NOT displayed on LogIn page");
            });

        }

    }
}
