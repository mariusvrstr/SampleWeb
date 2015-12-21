namespace Spike.Instrumentation.CustomLoggers
{
    using System;

    public class ServiceLogging : Logging
    {
        public override void Verbose(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Verbose, msg);
            }
        }

        public override void Debug(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Debug, msg);
            }
        }

        public override void Info(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Info, msg);
            }
        }

        public override void Warn(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Warn, msg);
            }
        }

        public override void Error(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Error, msg);
            }
        }

        public override Guid ErrorWithRef(string msg)
        {
            var errorToken = Guid.NewGuid();
            var message = string.Format("{0} - Reference [{1}]", msg, errorToken);

            if (Environment.UserInteractive)
            {
                Console.WriteLine(message);
            }
            else
            {
                WriteLog(LogLevel.Error, message);
            }

            return errorToken;
        }

        public override void Critical(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
                Console.ReadKey();
            }
            else
            {
                WriteLog(LogLevel.Critical, msg);
            }
        }
    }
}
