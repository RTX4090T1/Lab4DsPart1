using ConsoleApp24.Context;
using ConsoleApp24.Entities;
using ConsoleApp24.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    public class SetCookies(IBaseUrl _url, IClient _getId) : ISetCookies
    {
        public async Task Set_Cookies(IWebDriver driver)
        {
            try
            {
                using(var context = new ContextDb())
                {
                    var cookie = context.Cookies.FirstOrDefault(c => c.OwnerId == _getId.GetId());
                    if (cookie != null)
                    {
                        var seleniumCookie = new Cookie(
                            cookie.Name,
                            cookie.Value,
                            cookie.Domain,
                            cookie.Path,
                            cookie.Expiry,
                            cookie.IsSecure,
                            cookie.IsHttpOnly,
                            cookie.sameSiteValues
                        );
                        driver.Manage().Cookies.AddCookie(seleniumCookie);
                        driver.Navigate().GoToUrl(_url.GetBaseUrl());
                        driver.Navigate().Refresh();
                    }
                }
            }
            catch (Exception ex)
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
