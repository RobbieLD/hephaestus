using Hephaestus.Enums;
using Hephaestus.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hephaestus.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly LoggingContext _loggingContext;

        public LoggingService(LoggingContext loggingContext)
        {
            this._loggingContext = loggingContext;
        }
        public void LogDebug(string message)
        {
            this.Log(LogLevel.Debug, message);
        }

        public void LogError(string message)
        {
            this.Log(LogLevel.Error, message);
        }

        public void LogInformation(string message)
        {
            this.Log(LogLevel.Info, message);
        }

        public IList<LogEntry> Logs()
        {
            return this._loggingContext.Logs.OrderBy(l => l.Time).ToList();
        }


        public void LogWarning(string message)
        {
            this.Log(LogLevel.Warning, message);
        }

        public void Purge()
        {
            throw new Exception("Not done yet");
        }

        private void Log(LogLevel level, string message)
        {
            this._loggingContext.Add(new LogEntry
            {
                Level = level,
                Message = message,
                Time = DateTime.Now
            });
            this._loggingContext.SaveChanges();
        }
    }
}
