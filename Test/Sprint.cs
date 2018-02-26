using System;
using Ebay.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Ebay
{
    
    public class Sprint
    {
        class Keys : Base
        {
            //Validating the signin functionality.
            [Test]
            public void ValidateSignin()
            {
                var search = new SearchPage();
                search.ValidateSignin();

            }

            //Validating Error message on Signin page for Invalid Data.
            [Test]
            public void ValidateSigninErrormessage()
            {
                var search = new SearchPage();
                search.ValidateErrorMsg();

            }

            //Validate Advanced Search functionality.
            [Test]
            public void ValidateAdvancedSearch()
            {
                var search = new SearchPage();
                search.ValidateSearch();

            }
           
        }
    }
}
