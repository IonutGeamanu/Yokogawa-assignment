using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yokogawa_yahoo_spam
{
    class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How = How.Id, Using = "login-username")]
        private IWebElement emailfield;
        [FindsBy(How = How.Id, Using = "login-passwd")]
        private IWebElement passfield;
        [FindsBy(How = How.Id, Using = "login-signin")]
        private IWebElement nextbutton;

        public void loginWithCredentials(string username, string pass)
        {
            emailfield.SendKeys(username);
            nextbutton.Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("login-passwd")));
            passfield.SendKeys(pass);
            nextbutton.Click();
        }
    }
    
}
