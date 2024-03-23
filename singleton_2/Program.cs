using System;
using System.Collections.Generic;

namespace SingletonPrintBuffer
{
    public sealed class PrintBuffer
    {
        private static PrintBuffer? instance;
        private Queue<string> printQueue;
        private PrintBuffer() {
            printQueue = new Queue<string>();
        }

        public static PrintBuffer GetInstance()
        {
            if (instance == null)
            {
                instance = new PrintBuffer();
            }
            return instance;
        }
        public void Add(string message)
        {
            printQueue.Enqueue(message);
        }
        public string Consume()
        {
            if (printQueue.Count > 0)
            {
                return printQueue.Dequeue();
            }
            else
            {
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PrintBuffer pb = PrintBuffer.GetInstance();
            pb.Add("First data to print");
            pb.Add("Second data to print");
            PrintBuffer pb2 = PrintBuffer.GetInstance();
            pb2.Add("Third data to print");

            if (pb == pb2)
            {
                Console.WriteLine("buffers are the same instance");
            }
            else
            {
                Console.WriteLine("buffers are different instances");
            }

            while (true)
            {
                string message = pb.Consume();
                if (message == null)
                {
                    Console.WriteLine("No more messages to print");
                    break;
                }
                Console.WriteLine("Printing: " + message);
            }
        }
    }
}
