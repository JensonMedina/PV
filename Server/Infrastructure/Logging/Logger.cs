using Application.Common.Interfaces;
using System;
using System.IO;

namespace Infrastructure.Logging
{
    public class Logger : ILoggerApp
    {
        private static readonly object _lock = new object();
        private readonly string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
        private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB

        public Logger()
        {
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        private string GetLogFilePath()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string baseFileName = Path.Combine(logDirectory, $"logs-{date}");
            int count = 0;
            string logFilePath = $"{baseFileName}-{count}.txt";

            while (File.Exists(logFilePath) && new FileInfo(logFilePath).Length >= MaxFileSize)
            {
                count++;
                logFilePath = $"{baseFileName}-{count}.txt";
            }

            return logFilePath;
        }

        public void LogInfo(string context, string message, string? additionalData = null)
        {
            WriteLog("INFO", context, message, additionalData);
        }

        public void LogError(string context, string message, string? additionalData = null)
        {
            WriteLog("ERROR", context, message, additionalData);
        }

        private void WriteLog(string level, string context, string message, string? additionalData)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string logLine = $"[{timestamp}] [Th - {Environment.CurrentManagedThreadId}] [{level}] {context}: {message}";

            if (!string.IsNullOrWhiteSpace(additionalData))
            {
                logLine += $" [{additionalData}]";
            }

            lock (_lock)
            {
                try
                {
                    string logFilePath = GetLogFilePath();
                    File.AppendAllText(logFilePath, logLine + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al escribir en el log: {ex.Message}");
                }
            }
        }
    }
}