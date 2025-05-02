using ConsoleApp24.Entities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Interfaces
{
    public interface ISetCookies
    {
        public Task Set_Cookies(IWebDriver driver);
    }
}
