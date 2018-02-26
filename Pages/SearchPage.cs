using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoItX3Lib;
using Ebay;
using Ebay.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Ebay.Pages
{
    class SearchPage
    {
        public SearchPage()
        {
            PageFactory.InitElements(Driver.driver, this);
            ExcelLibHelpers.PopulateInCollection(Base.ExcelPath, "Signin");
        }

        //'Hi <username>' label
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/header/div/ul[1]/li[1]/button")]
        public IWebElement SignedinUsername { get; set; }

        //signout link
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/header/div/ul[1]/li[1]/div/ul/li[5]/a")]
        public IWebElement Signout { get; set; }

        // Finding the Error message
        [FindsBy(How = How.XPath, Using = "//span[@id='errf']")]
        private IWebElement ErrorMsg { get; set; }

        // Advanced Link
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/header/table/tbody/tr/td[3]/form/table/tbody/tr/td[4]/a")]
        private IWebElement AdvancedLnk { get; set; }

        // Keyword textbox
        [FindsBy(How = How.XPath, Using = "//input[@id='_nkw']")]
        private IWebElement KeywrdTxtbox { get; set; }
        
        // 'Buy It Now' Checkbox
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div/div/div/form/fieldset[4]/label[2]/input")]
        private IWebElement BuyNowCheckbx { get; set; }

        // Search button on Advanced search page
        [FindsBy(How = How.XPath, Using = "//button[@id='searchBtnLowerLnk']")]
        private IWebElement AdvanceSearchBtn { get; set; }

        // No Results Text
        [FindsBy(How = How.XPath, Using = "html/body/div[5]/div[2]/div[1]/div[1]/div/div[1]/div/div[1]/div/div[3]/h1")]
        private IWebElement ResultLbl { get; set; }


        //Validating Signin Functionality
        internal void ValidateSignin()
        {
            //click first item in menu bar.
            SignedinUsername.Click();
            Thread.Sleep(5000);
            var userlbl = Driver.driver.FindElement(By.XPath(".//*[@class='gh-ua gh-control']/b[1]")).Text;
            if (userlbl == ExcelLibHelpers.ReadData(2, "namedisplay"))
            {
              Console.WriteLine("Test case Passed. User successfully signed in and Username is appearing after sign in.");
            }
            else
            {
              Console.WriteLine("Test case Failed. Username is not appearing after sign in."); }
            //click signout
            Signout.Click();

        }
        
        //Validating error messages on signin page.
        internal void ValidateErrorMsg()
        {
            if (ErrorMsg.Displayed)
            {
                Console.WriteLine("Test case Passed. Error message for wrong email address appears");
            }
            else { Console.WriteLine("Test case Failed. Error message does not appear."); }
        }

        //Validate the functionality of 'Search' Button with valid data.
        
        internal void ValidateSearch()
        {
            ExcelLibHelpers.PopulateInCollection(Base.ExcelPath, "Search");
            AdvancedLnk.Click();
            KeywrdTxtbox.SendKeys(ExcelLibHelpers.ReadData(3, "searchKeyword"));
            BuyNowCheckbx.Click();
            AdvanceSearchBtn.Click();
            Thread.Sleep(4000);
            var ResultLbl = Driver.driver.FindElement(By.XPath("html/body/div[5]/div[2]/div[1]/div[1]/div/div[1]/div/div[1]/div/div[3]/h1")).Text;
            if (ResultLbl == ExcelLibHelpers.ReadData(2, "searchresult"))
            {
                Console.WriteLine("Test case Passed. 0 results found.");
            }
            else
            {

                for (var i = 1; i <= 50; i++)
                {
                    var SearchResult = Driver.driver.FindElement(By.XPath("html/body/div[5]/div[2]/div[1]/div[1]/div/div[1]/div/div[3]/div/div[1]/div/w-root/div/div/ul/li[" + i + "]/h3")).Text;
                    if (SearchResult.StartsWith(ExcelLibHelpers.ReadData(2, "searchKeyword")))
                    {
                        Console.WriteLine("Test case Passed. Searched record found.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Test case Failed. Searched record not found.");
                    }

                }



            }

        }
        
   
        }
    }

