using NLog;
using System;

namespace SDO.SnipsAI.Client.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeLogging();

            var snipsClient = new SnipsClient();

            snipsClient.RegisterDialog(new TestDialog());
            snipsClient.Connect("127.0.0.1");

            Console.ReadLine();
        }

        static void InitializeLogging()
        {
            LogManager.ReconfigExistingLoggers();
            var log = LogManager.GetCurrentClassLogger();
            log.Info("Log initialized");
        }
    }
}
