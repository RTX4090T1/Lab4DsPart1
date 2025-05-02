using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp24.Interfaces;

namespace ConsoleApp24.Entities
{
    public class BaseUrl(IBaseUrlValidate _validate) : IBaseUrl
    {
        public string Url { get; set; }
        public void SetBaseUrl(string url)
        {
            if (_validate.Validate(url))
            {
                Url = url;
            }
            else
            {
                throw new ArgumentException("Invalid URL format.");
            }
        }
        public string GetBaseUrl()
        {
            if (string.IsNullOrEmpty(Url))
            {
                throw new InvalidOperationException("Base URL is not set.");
            }
            return Url;
        }
    }
}
