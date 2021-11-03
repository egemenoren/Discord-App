using System;
using System.Threading.Tasks;

namespace Discord_App
{
    class Program
    {

        public static async Task Main(string[] args)
        {
           await Startup.RunAsync(args);
        }
    }
}
