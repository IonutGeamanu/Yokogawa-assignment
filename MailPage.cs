using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yokogawa_yahoo_spam
{
    class MailPage
    {
        IWebDriver driver;
        public MailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div[2]/div/div[1]/nav/div/div[3]/div[1]/ul/li[7]/div/a/span[1]")]
        private IWebElement spamfolder;
        
        //Checking the spam folder to see if any emails are inside by looking at the first row in table
        public bool verifySpamFolder()
        {
            spamfolder.Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='mail-app-component']//button[@data-test-id='toolbar-not-spam']")));
            try
            {
                return !driver.FindElement(By.XPath("//*[@id='mail-app-component']/div/div/div[2]/div/div/div[2]/div/div[1]/ul/li[2]/a/div/div[1]/div[1]/button")).Displayed;
            }catch (NoSuchElementException e)
            {
                return true;
            }                            
            
        }
       

       
    }
}

