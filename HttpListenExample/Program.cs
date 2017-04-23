using Microsoft.Owin.Hosting;
using System;

namespace HttpListenExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var url = "http://+:30001";
            
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", url);
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }            
        }
    }
}
