using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace WebShit
{
    internal class TwoFaktorLogin
    {
        IWebDriver driver;

        string nameField = "login-form_username";
        string passwordField = "login-form_password";
        string submitButton = "login-submit-button";

        string cimtar;
        string password;



        public TwoFaktorLogin(IWebDriver driver)
        {
            this.driver = driver;
            cimtar = CoolInfo.EDUNUMBER;
            password = CoolInfo.EDUPASS;
        }

        public bool Login()
        {

            IWebElement name= driver.FindElement(By.Id(nameField));
            IWebElement pass= driver.FindElement(By.Id(passwordField));
            IWebElement submit= driver.FindElement(By.Id(submitButton));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            name.Clear();
            pass.Clear();
            
            name.SendKeys(cimtar);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            pass.SendKeys(password);

            
            submit.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);

            string strUrl = driver.Url;

            if (driver.Url.Contains("login"))
            {
                return false;
            }

            if (driver.Url.Contains("bme.hu"))
            {
                return true;
            }

            return false;


        }


    }
}
