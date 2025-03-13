using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace MentalEdu.BlazorApp.Client.Services
{
    public class LoggingService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly List<LogEntry> _logs = new List<LogEntry>();

        public LoggingService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public void LogError(string message, Exception ex = null)
        {
            var logEntry = new LogEntry
            {
                Timestamp = DateTime.Now,
                Level = "ERROR",
                Message = message,
                Exception = ex?.ToString()
            };

            _logs.Add(logEntry);
            
            // In development, we can still see it in the console
            Console.Error.WriteLine($"ERROR: {message}");
            if (ex != null)
            {
                Console.Error.WriteLine($"Exception: {ex}");
            }
        }

        public void LogInfo(string message)
        {
            var logEntry = new LogEntry
            {
                Timestamp = DateTime.Now,
                Level = "INFO",
                Message = message
            };

            _logs.Add(logEntry);
        }

        public async Task ShowErrorToUser(string message)
        {
            await _jsRuntime.InvokeVoidAsync("alert", $"Error: {message}");
        }

        public List<LogEntry> GetLogs()
        {
            return _logs;
        }

        public class LogEntry
        {
            public DateTime Timestamp { get; set; }
            public string Level { get; set; }
            public string Message { get; set; }
            public string Exception { get; set; }
        }
    }
}