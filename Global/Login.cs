using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Ebay.Global
{
    class Login
    { // Initializing the web elements 
        internal Login()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        // Finding the Signin link
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Sign in')]")]
        private IWebElement SigninLnk { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "//input[@id='userid']")]
        private IWebElement Username { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//input[@id='pass']")]
        private IWebElement Password { get; set; }

        // Finding the Sign in Button
        [FindsBy(How = How.XPath, Using = "//input[@id='sgnBt']")]
        private IWebElement SigninButton { get; set; }

        
        internal void LoginSuccessfull()
        {
            // Populating the data from Excel
            ExcelLibHelpers.PopulateInCollection(Base.ExcelPath, "Signin");
            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLibHelpers.ReadData(2, "url"));
            //Clicking Signin link from menu bar
            SigninLnk.Click();
            // Sending the username 
            Username.SendKeys(ExcelLibHelpers.ReadData(2, "email"));
            // Sending the password
            Password.SendKeys(ExcelLibHelpers.ReadData(2, "password"));
            // Clicking on the login button
            SigninButton.Click();


        }

        
    }
}
