using ConsoleApp24.Entities;
using ConsoleApp24.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using ConsoleApp24.Context;

namespace ConsoleApp24
{
    public class GetGoods(IClient _getClient) : IGetGoods
    {
        public async Task Get_Goods(string url)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            var goods = driver.FindElements(By.XPath("//div[contains(@class,'list-item__photo-text-container') and @data-v-292db23b]"));
            List<Goods> goodsList = [];
            foreach (var item in goods)
            {
                Goods good = new()
                {
                    Name = item.FindElement(By.XPath("//a[contains(@class,'item-title') and contains(@class,'text-md') and contains(@class,'link') and contains(@class,'link--black') @data-v-f09e5ece]")).Text,
                    Price = string.Concat(Regex.Matches(item.FindElement(By.XPath("//div[contains(@class,'list-item__value-price') and contains(@class, 'text-md') and contains(@class, 'text-orange') and contains(@class, 'text-lh--1') and @data-v-292db23b]")).Text, @"[0-9\-]+")),
                    Description = item.FindElement(By.XPath("//span[contains(@class,'spec-item') or contains(@class, 'spec-item--bullet') and @data-v-b1c38726]")).Text,
                    ImageUrl = item.FindElement(By.XPath("//img[contains(@class,'rounded-border--sm') and  @data-v-292db23b]")).GetAttribute("src"),
                    OwnerId = _getClient.GetId(),
                };
                goodsList.Add(good);
            }
            using(var context = new ContextDb())
            {
                await context.ScrapedData.AddRangeAsync(goodsList);
            }

        }
    }
}
