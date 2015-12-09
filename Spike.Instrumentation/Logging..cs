
namespace Spike.Instrumentation
{
    using System;
    using NLog;

    public class Logging
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Info(string msg)
        {
            Logger.Info(msg);
        }

        public static Guid Error(string msg)
        {
            var errorToken = NewErrorToken();
            Logger.Error("{0} ErrorToken={1}", msg, errorToken);

            return errorToken;
        }
        
        private static Guid NewErrorToken()
        {
            return new Guid();
        }
    }
}
