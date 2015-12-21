namespace Spike.Instrumentation
{
    using System;
    using NLog;

    public class Logging : ILogging
    {
        private const string DefaultModule = "";
        public string Module { get; private set; }

        public Logging() : this(null) { }

        public Logging(string module = DefaultModule)
        {
            Module = string.IsNullOrWhiteSpace(module) ? module : string.Format("{0}::", module);
        }

        private static Logger _logger;

        protected static Logger LocalLogger
        {
            get
            {
                if (_logger != null)
                {
                    return _logger;
                }

                return _logger = LogManager.GetCurrentClassLogger();
            }
        }

        public virtual void Verbose(string msg)
        {
            WriteLog(LogLevel.Verbose, msg);
        }

        public void Verbose(string msg, params object[] messageArgs)
        {
            this.Verbose(string.Format(msg, messageArgs));
        }

        public virtual void Debug(string msg)
        {
            WriteLog(LogLevel.Debug, msg);
        }

        public void Debug(string msg, params object[] messageArgs)
        {
            this.Debug(string.Format(msg, messageArgs));
        }

        public virtual void Info(string msg)
        {
            WriteLog(LogLevel.Info, msg);
        }

        public void Info(string msg, params object[] messageArgs)
        {
            this.Info(string.Format(msg, messageArgs));
        }

        public virtual void Warn(string msg)
        {
            WriteLog(LogLevel.Warn, msg);
        }

        public void Warn(string msg, params object[] messageArgs)
        {
            this.Warn(string.Format(msg, messageArgs));
        }

        public virtual void Error(string msg)
        {
            this.WriteLog(LogLevel.Error, msg);
        }

        public void Error(string msg, params object[] messageArgs)
        {
            this.Error(string.Format(msg, messageArgs));
        }

        public virtual Guid ErrorWithRef(string msg)
        {
            var errorToken = Guid.NewGuid();
            this.WriteLog(
                LogLevel.Error,
                string.Format("{0} - Reference [{1}]", msg, errorToken));

            return errorToken;
        }

        public Guid ErrorWithRef(string msg, params object[] messageArgs)
        {
            return this.ErrorWithRef(string.Format(msg, messageArgs));
        }

        public virtual void Critical(string msg)
        {
            WriteLog(LogLevel.Critical, msg);
        }

        public void Critical(string msg, params object[] messageArgs)
        {
            this.Critical(string.Format(msg, messageArgs));
        }

        public void Dispose() {}

        protected void WriteLog(LogLevel logLevel, string msg)
        {
            var theEvent = new LogEventInfo(Map(logLevel), "", msg);
            theEvent.Properties["Module"] = this.Module;
            LocalLogger.Log(theEvent);
        }

        public bool IsVerbose
        {
            get { return LocalLogger.IsTraceEnabled; }
        }

        private static NLog.LogLevel Map(LogLevel original)
        {
            switch (original)
            {
                case LogLevel.Verbose:
                    return NLog.LogLevel.Trace;
                case LogLevel.Info:
                    return NLog.LogLevel.Info;
                case LogLevel.Debug:
                    return NLog.LogLevel.Debug;
                case LogLevel.Warn:
                    return NLog.LogLevel.Warn;
                case LogLevel.Error:
                    return NLog.LogLevel.Error;
                case LogLevel.Critical:
                    return NLog.LogLevel.Fatal;
                default:
                    throw new InvalidCastException(string.Format("Unknown Log Level [{0}]", original));
            }
        }
    }
}
