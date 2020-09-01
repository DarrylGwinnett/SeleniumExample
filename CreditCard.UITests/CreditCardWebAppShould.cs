﻿using Xunit;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace CreditCard.UITests
{
    public class CreditCardWebAppShould
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                Assert.Equal("Home Page - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/", driver.Url);
                
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

        
                driver.Navigate().GoToUrl("http://localhost:44108/");
                IWebElement guidElementFirst = driver.FindElement(By.Id("GenerationToken"));
                string firstToken = guidElementFirst.Text;
                Thread.Sleep(3000);
                driver.Navigate().Refresh();
                Thread.Sleep(3000);
                Assert.Equal("Home Page - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/", driver.Url);
                Thread.Sleep(3000);
                string reloadedToken = driver.FindElement(By.Id("GenerationToken")).Text;
                Assert.NotEqual(firstToken, reloadedToken);



            }
        }
    }
}
