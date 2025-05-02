using ConsoleApp24.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    public class GetCatalogUrl(IBaseUrl _url, IGetGoods _goods) : IGetCatalogUrl
    {
        public async Task Get_CatalogUrl(string catUrl)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(_url.GetBaseUrl() + catUrl);
            var catalogs = driver.FindElements(By.XPath("//div[contains(@class,'section-navigation__item') and contains(@class,'content') and @data-v-5a2f1b58 and @data-v-23587d63]"));
            List<string> catalogsHrefList = [];
            foreach (var href in catalogs)
            {
                catalogsHrefList.Append(href.GetAttribute("href"));
            }
            Console.WriteLine("Chose catalog: ");
            int catNum = Convert.ToInt32(Console.ReadLine());
            await _goods.Get_Goods(_url.GetBaseUrl() + catalogsHrefList[catNum]);
        }
    }
}
