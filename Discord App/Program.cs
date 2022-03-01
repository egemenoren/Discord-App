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
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to Exit");
        }
    }
}
