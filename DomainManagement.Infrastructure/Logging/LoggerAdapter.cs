
using DomainManagement.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Infrastructure.Logging
{
    // This class acts as an adapter for the Microsoft.Extensions.Logging infrastructure, allowing it to be used where an IAppLogger<T> is expected.
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        // A private field to hold the reference to the Microsoft.Extensions.Logging logger.
        private readonly ILogger<T> _logger;

        // Constructor that takes an ILoggerFactory as a dependency and initializes the private logger field.
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            // Uses the logger factory to create a logger specific to the type T.
            _logger = loggerFactory.CreateLogger<T>();
        }

        // Logs informational messages. Accepts a format string and an optional array of arguments, and delegates the call to the underlying logger.
        public void LogInformation(string message, params object[] args)
        {
            // Logs the information level message using the Microsoft.Extensions.Logging infrastructure.
            _logger.LogInformation(message, args);
        }

        // Logs warning messages. Accepts a format string and an optional array of arguments, and delegates the call to the underlying logger.
        public void LogWarning(string message, params object[] args)
        {
            // Logs the warning level message using the Microsoft.Extensions.Logging infrastructure.
            _logger.LogWarning(message, args);
        }
    }
}
