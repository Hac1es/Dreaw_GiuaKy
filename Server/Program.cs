using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Ứng dụng vẽ chung qua mạng - Dreaw");
            Console.ResetColor();
            ServerClass Dreaw_Server = new ServerClass();
        }
    }
}
