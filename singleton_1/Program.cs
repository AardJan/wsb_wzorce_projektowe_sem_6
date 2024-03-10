using System;

namespace SingletonLoggerExample
{
    public sealed class LoggerClass
    {
        private static LoggerClass? instance;
        private List<string> messages;
        private LoggerClass() {
            messages = new List<string>();
        }

        public static LoggerClass GetInstance()
        {
            if (instance == null)
            {
                instance = new LoggerClass();
            }
            return instance;
        }
        public void LogMessage(string message)
        {
            messages.Add(message);
        }
        public List<string> GetMessages()
        {
            return messages;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LoggerClass logger = LoggerClass.GetInstance();
            logger.LogMessage("First message");
            logger.LogMessage("Second message");
            LoggerClass logger2 = LoggerClass.GetInstance();
            logger2.LogMessage("Third message in logger2");
            List<string> messages = logger2.GetMessages();
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
