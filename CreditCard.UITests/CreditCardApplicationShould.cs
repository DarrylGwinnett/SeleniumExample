using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using SeleniumExtras.WaitHelpers;
using Xunit.Abstractions;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CreditCard.UITests
{
    public class CreditCardApplicationShould
    {

        private readonly ITestOutputHelper output;

        public string ApplyURL = "http://localhost:44108/Apply";

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
                //IWebElement caroselNext = driver.FindElement(By.CssSelector("[data-slide='next']"));
                //caroselNext.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(11));
                IWebElement applyButton = wait.Until((d) => d.FindElement(By.LinkText(("Easy: Apply Now!"))));
                applyButton.Click();
                Thread.Sleep(1000);
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/Apply", driver.Url);
            }

        }

        [Fact]
        [Trait("Category", "Application")]
        public void BeInitiatedFromHomePage_EasyApplyNow_PrebuiltConditions()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                Assert.Equal("Home Page - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/", driver.Url);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(11));
                IWebElement applyButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Easy: Apply Now!")));
                applyButton.Click();
                Thread.Sleep(1000);
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/Apply", driver.Url);
            }
        }

        [Fact]
        public void BeInitiatedFromHomePage_CustomerService()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                IWebElement caroselNext = driver.FindElement(By.CssSelector("[data-slide='next']"));
                //caroselNext.Click();
                //Thread.Sleep(1000);
                //caroselNext.Click();
                //Thread.Sleep(1000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(35));
                IWebElement applyLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("customer-service-apply-now")));
                applyLink.Click();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/Apply", driver.Url);
            }
        }


        [Fact]
        public void BeInitiatedFromHomePage_RandomGreeting()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                IWebElement randomGreetingApplyLink = driver.FindElement(By.PartialLinkText("Apply Now"));
                randomGreetingApplyLink.Click();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/Apply", driver.Url);
            }
        }

        [Fact]
        public void BeInitiatedFromHomePage_RandomGreeting_XPath()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                IWebElement randomGreetingApplyLink = driver.FindElement(By.XPath("/html/body/div/div[4]/div/p/a"));
                randomGreetingApplyLink.Click();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/Apply", driver.Url);
            }
        }


        [Fact]
        public void BeInitiatedFromHomePage_RandomGreeting_XPath_Relative()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                IWebElement randomGreetingApplyLink = driver.FindElement(By.XPath("//div/div[4]/div/p/a"));
                randomGreetingApplyLink.Click();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/Apply", driver.Url);
            }
        }

        [Fact]
        public void BeSubmittedWhenValid()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(ApplyURL);
                driver.FindElement(By.Id("FirstName")).SendKeys("Sarah");
                driver.FindElement(By.Id("LastName")).SendKeys("Smith");
                driver.FindElement(By.Id("FrequentFlyerNumber")).SendKeys("34565");
                driver.FindElement(By.Id("Age")).SendKeys("18");
                driver.FindElement(By.Id("GrossAnnualIncome")).SendKeys("50000");

                driver.FindElement(By.Id("Single")).Click();
                IWebElement businessSourceSelect = driver.FindElement(By.Id("BusinessSource"));
                SelectElement businessSource = new SelectElement(businessSourceSelect);
                businessSource.SelectByText("Word of Mouth");
                driver.FindElement(By.Id("TermsAccepted")).Click();
     
                driver.FindElement(By.Id("SubmitApplication")).Click();
            }
        }
    }
}



