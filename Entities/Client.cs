using ConsoleApp24.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Entities
{
    public class Client : IClient
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string GetId()
        {
            return Id.ToString();
        }
    }
}
