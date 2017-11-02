using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTrivia.Scripts
{
    
    class Loggin
    {
        IWebDriver driver;

        public Loggin(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void Signin(String username, String pass)
        {
            driver.FindElement(By.Id("UserUser")).SendKeys(username);
            driver.FindElement(By.Id("UserPass")).SendKeys(pass);
            driver.FindElement(By.XPath("//*[@id='UserLoginForm']/div[2]/input")).Click();
        }
    }
}
