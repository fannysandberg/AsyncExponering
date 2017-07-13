using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExponering
{
    class AsyncAwaitTaskDemo
    {
        //Step 1 - skapa en metod som tar lång tid att köra (för demonstration)
        string DoTimeConsumingWork(string s, StringAction stringAction)
        {
            Console.WriteLine($"DoTimeConsumingWork Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            int sleepTime = new Random().Next(5000, 10001);
            Thread.Sleep(sleepTime);

            string stringValue = string.Empty; //ett plattformsoberoende sätt att skriva  "" (en tom sträng alltså)

            switch (stringAction)
            {
                case StringAction.UpperCase:
                    stringValue = s.ToUpper();
                    break;
                case StringAction.LowerCase:
                    stringValue = s.ToLower();
                    break;
                case StringAction.Backward:
                    stringValue = new string(s.Reverse().ToArray());
                    break;
           
            }

            return stringValue;

        }

        //Step 2, skapa en likadan metod men som är async (och heter async pga best practise)
        Task<string> DoTimeConsumingWorkAsync(string s, StringAction stringAction)
        {
            Console.WriteLine($"DoTimeConsumingWorkAsync Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            //lambda anropar metoden dotimeconsumingwork
            return Task.Run(() =>
            {
                return DoTimeConsumingWork(s, stringAction);
            });
        
        }

        public void CallAwaitableMethod()
        {
            Task<string> task = DoTimeConsumingWorkAsync("hÅKan JoHaNSSon", StringAction.UpperCase);
            Console.WriteLine("This program is now running two threads");
            Console.WriteLine("Please wait for the awaitable method to return");
            string typeParameterReturnValue = task.Result;
            Console.WriteLine($"The asynchronous call returned {typeParameterReturnValue}");
        }

        public async void DemoAsyncAwait() //Note async!
        {
            Console.WriteLine($"DemoASyncAwait Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            string s = await DoTimeConsumingWorkAsync("hÅKan JoHaNSSon", StringAction.UpperCase);

            Console.WriteLine($"Callback Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            //Callback code. 
            Console.WriteLine(s);
        }

    }
}
