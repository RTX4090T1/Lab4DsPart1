using ConsoleApp24.Context;
using ConsoleApp24.Entities;
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
    public class GetSelected(IBaseUrl _getUrl,IClient _getClient) : IGetSelected
    {
        public async Task Get_Selected()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(_getUrl.GetBaseUrl());
            IWebElement divSelect = driver.FindElement(By.XPath("//div[contains(@class,'button') and contains(@class, 'flex-column') and contains(@class, 'middle-xs') and contains(@class,'center-xs') and contains(@class, 'header__icon') and @data-v-d121e446 and @data-v-7e03ec13]"));
            divSelect.Click();
            IWebElement buttonGetSelect = divSelect.FindElement(By.XPath("//a[contains(@class,'link--black' ) and data-v-7d2b9197]"));
            buttonGetSelect.Click();
            var selected = driver.FindElements(By.XPath("//div[contains(@class,'list-item  list-item--row--profile') and contains(@class,'list-item--row--profile') and contains(@class,'list-item--row') and @data-v-292db23b]"));
            using(var context = new ContextDb())
            {
                foreach (var item in selected)
                {
                    var chosen = new Selected()
                    {
                        Name = item.FindElement(By.XPath("//a[contains(@class,'item-title') and contains(@class,'text-md') and contains(@class,'link') and contains(@class,'link--black') and @data-v-f09e5ece]")).Text,
                        Price = item.FindElement(By.XPath("//div[contains(@class,'list-item__value-price') and contains(@class, 'text-md') and contains(@class, 'text-orange') and contains(@class, 'text-lh--1') and @data-v-292db23b]")).Text,
                        Description = item.FindElement(By.XPath("//span[contains(@class,'spec-item') or contains(@class, 'spec-item--bullet') and @data-v-b1c38726]")).Text,
                        ImageUrl = item.FindElement(By.XPath("//img[contains(@class,'rounded-border--sm') and  @data-v-292db23b]")).GetAttribute("src"),
                        OwnerId = _getClient.GetId(),
                    };
                    var exist = context.Selected.Any(selected => selected.Name == chosen.Name && selected.Price == chosen.Price && selected.Description == chosen.Description);
                    if(exist)
                    {
                        Console.WriteLine("Selected already exists in the database.");
                        continue;
                    }
                    else
                    {
                        await context.Selected.AddAsync(chosen);
                    }                    
                }
            }
        }
    }
}
