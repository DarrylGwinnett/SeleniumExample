using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CreditCard.UITests
{
    public class CreditCardApplicationShould
    {
        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePage_NewLowRate()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                Assert.Equal("Home Page - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/", driver.Url);
                IWebElement applyButton = driver.FindElement(By.Name("ApplyLowRate"));
                applyButton.Click();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/Apply", driver.Url);
            }

        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePage_EasyApplyNow()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                Assert.Equal("Home Page - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/", driver.Url);
                Thread.Sleep(11000);
                IWebElement applyButton = driver.FindElement(By.LinkText("Easy: Apply Now!"));
                applyButton.Click();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/Apply", driver.Url);
            }

        }
    }
}



