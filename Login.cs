using ConsoleApp24.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ConsoleApp24.Entities;

namespace ConsoleApp24
{
    public class Login(IBaseUrl _url, IGetCookies _get) : ILogin
    {
        public async void Login_(Client creds)
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                string url = _url.GetBaseUrl();
                driver.Navigate().GoToUrl(url);
                IWebElement emailField = driver.FindElement(By.XPath("//input[@type='text' and @placeholder='E-mail або номер мобільного телефону' and contains(@class, 'field') and contains(@class, 'm_b-5')]"));
                IWebElement passwordField = driver.FindElement(By.XPath("//input[@type='password' and @placeholder='Пароль' and contains(@class, 'password') and contains(@class, 'm_b-5')]"));
                emailField.SendKeys(creds.Email);
                passwordField.SendKeys(creds.Password);
                IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit' and contains(@class, 'btn') and contains(@class, 'btn') and contains(@class, 'btn--graphite') and contains(@class, 'rounded-border--lg') and contains(@class, 'm_b-10')]"));
                loginButton.Click();
                await _get.GetCookies_(driver);
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                driver.Quit(); 
            }
        }   
    }
}
