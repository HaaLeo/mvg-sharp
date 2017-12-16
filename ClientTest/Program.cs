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
            var result = apiClient.GetNerbyStations(48.181108, 11.511545).Result;
        }
    }
}
