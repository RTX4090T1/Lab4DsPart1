using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp24.Interfaces;

namespace ConsoleApp24
{
    public class BaseUrlValidate :IBaseUrlValidate
    {
        public bool Validate(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}
