using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Yokogawa_yahoo_spam
{
    class BaseClass
    {
        public ChromeDriver driver;
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https:\\mail.yahoo.com";

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
