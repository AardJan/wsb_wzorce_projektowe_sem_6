using System;

namespace AdapterLogger
{
    public sealed class OldLoggerClass
    {
        private static OldLoggerClass? instance;
        private List<string> messages;
        private OldLoggerClass() {
            messages = new List<string>();
        }

        public static OldLoggerClass GetInstance()
        {
            if (instance == null)
            {
                instance = new OldLoggerClass();
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

    public sealed class NewLoggerClass
    {
        private static NewLoggerClass? instance;
        private List<string> messages;
        private NewLoggerClass() {
            messages = new List<string>();
        }

        public static NewLoggerClass GetInstance()
        {
            if (instance == null)
            {
                instance = new NewLoggerClass();
            }
            return instance;
        }
        public void SendMessage(string message)
        {
            messages.Add(message);
        }
        public List<string> ListMessages()
        {
            return messages;
        }
    }

    public interface IOldLogger
    {
        void LogMessage(string message);

        List<string> GetMessages();
    }

    class Adapter: IOldLogger
    {
        private readonly NewLoggerClass _adaptee;

        public Adapter(NewLoggerClass adaptee)
        {
            this._adaptee = adaptee;
        }

        public void LogMessage(string message)
        {
            this._adaptee.SendMessage(message);
        }

        public List<string> GetMessages()
        {
            return this._adaptee.ListMessages();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            NewLoggerClass newLogger = NewLoggerClass.GetInstance();
            IOldLogger logger = new Adapter(newLogger);

            logger.LogMessage("First message");
            logger.LogMessage("Second message");
            logger.LogMessage("Third message");
            List<string> messages = logger.GetMessages();
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

        }
    }
}
