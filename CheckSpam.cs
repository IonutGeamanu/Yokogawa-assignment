using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;



namespace Yokogawa_yahoo_spam
{
    class CheckSpam : BaseClass
    {
        [Test]
        public void TestPage()
        {
            Console.WriteLine("Please enter your email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Please enter your password: ");
            string pass = Console.ReadLine();

            //use POM pattern as described in https://www.lambdatest.com/blog/page-object-model-tutorial-selenium-csharp/ documentation
            LoginPage loginPage = new LoginPage(driver);
            loginPage.loginWithCredentials(email, pass);

            MailPage mailpage = new MailPage(driver);
               
            Assert.True(mailpage.verifySpamFolder());
        }


        

    }

}