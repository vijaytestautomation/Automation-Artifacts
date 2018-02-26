using System;
using Ebay.Global;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Ebay
{
    public abstract class Base
    {

        #region To access path from Resource file
        public static int Browser = Int32.Parse(KeyResource.Browser);
        public static string ExcelPath = KeyResource.ExcelPath;
        public static string ScreenshotPath = KeyResource.ScreenShotPath;
        public static string ReportPath = KeyResource.ReportPath;
        #endregion


        #region setup and tear down
        [SetUp]
        public void Initialize()
        {
            switch (Browser)
            {
                case 1:
                    Driver.driver = new FirefoxDriver();
                    //Maximize browser window
                    Driver.driver.Manage().Window.Maximize();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    //Maximize browser window
                    Driver.driver.Manage().Window.Maximize();
                    break;
            }
            if (KeyResource.IsLogin == "true")
            {
                Login loginobj = new Login();
                loginobj.LoginSuccessfull();

            }
            else
            {
              //Register Module
            }
            
        }

        [TearDown]
        public void TearDown()
        {
            //Screenshot
            String img = SaveScreenShotClass.Capture(Driver.driver, "Report");
            Driver.driver.Close();
        }
        #endregion
    }
}
