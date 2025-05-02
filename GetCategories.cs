using ConsoleApp24.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    public class GetCategories(IBaseUrl _url,IGetCatalogUrl _catUrl) : IGetCategories
    {
        public async Task Get_Categories()
        {
            IWebDriver driver = new ChromeDriver();
            var baseUrl = _url.GetBaseUrl();
            driver.Navigate().GoToUrl(baseUrl);
            var categories = driver.FindElements(By.XPath("//div[contains(@class,'categories-section__link) and cantains(@class, 'link--black') and @data-v-61276768 and @data-tracking-id='index-5']"));
            List<string> categoryHrefList = [];
            foreach (var category in categories)
            {
                Console.WriteLine(category.GetAttribute("data-eventlabel"));

                categoryHrefList.Append(category.GetAttribute("href"));
            }
            Console.WriteLine("Chose category: ");
            int catNum = Convert.ToInt32(Console.ReadLine());
            await _catUrl.Get_CatalogUrl(baseUrl + categoryHrefList[catNum]);    
        }
    }
}
