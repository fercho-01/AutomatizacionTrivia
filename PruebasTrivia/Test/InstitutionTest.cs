using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PruebasTrivia.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebasTrivia.Test
{
    

    [TestFixture]
    class InstitutionTest
    {
        IWebDriver driver;
        Loggin login;
        String url = Constans.url;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            login = new Loggin(driver);
            driver.Navigate().GoToUrl(url + "/users/login");
            login.Signin("admin", "admin");
        }

        [Test]
        public void CreateIsnstitutionWithoutLogin()
        {
            driver.Navigate().GoToUrl(url + "/users/logout");
            driver.Navigate().GoToUrl(url + "/institutions/add");
            Thread.Sleep(10000);
            String urlLogin = Constans.url + "/users/login";
            Assert.IsTrue(urlLogin.Equals(driver.Url));
        }

        [Test]
        public void CheckButtonGoToInstitutions()
        {
            
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(5000);
            IWebElement institutionButton = driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[4]/a"));
            Assert.IsTrue(institutionButton != null);
        }

        [Test]
        public void CreateInstitutionWhitoutName()
        {
            driver.Navigate().GoToUrl(url + "/institutions/add");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='InstitutionAddForm']/div[2]/input")).Click();
            Thread.Sleep(5000);
            String currentUrl = url + "/institutions/add";
            Assert.IsTrue(currentUrl.Equals(driver.Url));
        }

        [Test]
        public void CreateInstitutionWithEmptyName()
        {
            driver.Navigate().GoToUrl(url + "/institutions/add");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("InstitutionName")).SendKeys("\"\"");
            driver.FindElement(By.XPath("//*[@id='InstitutionAddForm']/div[2]/input")).Click();
            Thread.Sleep(5000);
            String currentUrl = url + "/institutions/add";
            Assert.IsTrue(currentUrl.Equals(driver.Url));
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}
