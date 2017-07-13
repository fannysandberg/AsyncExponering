using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExponering
{
    enum StringAction
    {
        UpperCase,
        LowerCase,
        Backward
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            AsyncAwaitTaskDemo demo = new AsyncAwaitTaskDemo();
            demo.DemoAsyncAwait();
            Console.WriteLine("Press a key to quit now, or wait for an important message...");
            Console.ReadKey(true);
        }
    }
}
