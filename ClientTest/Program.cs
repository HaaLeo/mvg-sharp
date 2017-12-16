using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IClient apiClient = new MvgClient();
            var result = apiClient.GetRoute(1,2).Result;
        }
    }
}
