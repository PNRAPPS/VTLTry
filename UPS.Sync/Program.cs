using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Sync
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] subscriptions = new string[] { "Outbound", "ThirdParty" };

            foreach (var item in subscriptions)
            {
                Console.WriteLine("{0}: Getting {1}...", DateTime.Now.ToString(), item);
                var data = QuantumService.GetQuantumData(item);
            }

            Console.WriteLine("Done.");
        }
    }
}
