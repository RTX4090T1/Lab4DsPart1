using ConsoleApp24.Interfaces;
using OpenQA.Selenium;
using Newtonsoft.Json;
using ConsoleApp24.Entities;
using ConsoleApp24.Context;

namespace ConsoleApp24
{
    public class GetCookies(IClient _getId):IGetCookies
    {
        public async Task GetCookies_(IWebDriver driver)
        {
            try
            {
                var cookies = driver.Manage().Cookies.AllCookies;
                using (var context = new ContextDb())
                {   
                    foreach (var cookie in cookies)
                    {
                        var dbCookie = new Cookies
                        {
                            Name = cookie.Name,
                            Value = cookie.Value,
                            Domain = cookie.Domain,
                            Path = cookie.Path,
                            Expiry = cookie.Expiry,
                            IsSecure = cookie.Secure,
                            IsHttpOnly = cookie.IsHttpOnly,
                            OwnerId = _getId.GetId(), 
                        };
                        context.Cookies.Add(dbCookie);
                    }
                    context.SaveChanges();
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
