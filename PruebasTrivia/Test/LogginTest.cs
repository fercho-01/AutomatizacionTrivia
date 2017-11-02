using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PruebasTrivia.Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebasTrivia.Test
{
    [TestFixture]
    class LogginTest
    {
        IWebDriver driver;
        Loggin login;
        String url = "http://localhost:8081/triviador2";
        [OneTimeSetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            
            login = new Loggin(driver);
        }

        [Test]
        public void CorrectUserWrongPassword()
        {
            driver.Navigate().GoToUrl(url + "/users/login");
            login.Signin("admin4","pass");

            Thread.Sleep(5000);
            IWebElement element = driver.FindElement(By.Id("flashMessage"));
            Trace.WriteLine(element.Text);
            Assert.IsTrue("Usuario o contraseña incorrectos".Equals(element.Text));
        }

        [Test]
        public void WrongUserWrongPassword()
        {
            driver.Navigate().GoToUrl(url + "/users/login");
            login.Signin("user1", "user2");
            Thread.Sleep(5000);
            IWebElement element = driver.FindElement(By.Id("flashMessage"));
            Assert.IsTrue("Usuario o contraseña incorrectos".Equals(element.Text));
        }

        [Test]
        public void WrongUserCorrectPassword()
        {
            driver.Navigate().GoToUrl(url + "/users/login");
            login.Signin("user1", "admin4");
            Thread.Sleep(5000);
            IWebElement element = driver.FindElement(By.Id("flashMessage"));
            Assert.IsTrue("Usuario o contraseña incorrectos".Equals(element.Text));
        }

        [Test]
        public void CorrectUserCorrectPassword()
        {
            driver.Navigate().GoToUrl(url + "/users/login");
            login.Signin("admin", "admin");
            Thread.Sleep(10000);
            String currentUrl = driver.Url;
            driver.Navigate().GoToUrl(url + "/users/logout");
            Assert.IsTrue("http://localhost:8081/triviador2/questions".Equals(currentUrl));
            
        }
        [OneTimeTearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}
