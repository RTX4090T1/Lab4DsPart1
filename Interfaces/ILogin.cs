using ConsoleApp24.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Interfaces
{
    public interface ILogin
    {
        public void Login_(Client creds);
    }
}
