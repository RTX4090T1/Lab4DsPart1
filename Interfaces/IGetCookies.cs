using ConsoleApp24.Entities;
using OpenQA.Selenium;
using System.Collections;


namespace ConsoleApp24.Interfaces
{
    public interface IGetCookies
    {
        public Task GetCookies_(IWebDriver driver);
    }
}