﻿using Xunit;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.ObjectModel;

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

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                IWebElement guidElementFirst = driver.FindElement(By.Id("GenerationToken"));
                string firstToken = guidElementFirst.Text;
                driver.Navigate().GoToUrl("http://localhost:44108/Home/About");
                driver.Navigate().Back();
                string reloadedToken = driver.FindElement(By.Id("GenerationToken")).Text;
                Assert.NotEqual(firstToken, reloadedToken);
                Assert.Equal("Home Page - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/", driver.Url);
            }
        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnForward()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/Home/About");
                driver.Navigate().GoToUrl("http://localhost:44108/");
                IWebElement guidElementFirst = driver.FindElement(By.Id("GenerationToken"));
                string firstToken = guidElementFirst.Text;
                driver.Navigate().Back();
                driver.Navigate().Forward();
                string reloadedToken = driver.FindElement(By.Id("GenerationToken")).Text;
                Assert.NotEqual(firstToken, reloadedToken);
                Assert.Equal("Home Page - Credit Cards", driver.Title);
                Assert.Equal("http://localhost:44108/", driver.Url);
            }
        }

        [Fact]
        public void DisplayProductsAndRates()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:44108/");
                ReadOnlyCollection<IWebElement> tableCells = driver.FindElements(By.TagName("td"));
                Assert.Equal("Easy Credit Card", tableCells[0].Text);

                //TODO: check rest of product table
            }
        }
    }
}
