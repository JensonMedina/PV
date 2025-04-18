using Application.Common.Interfaces;
using System;
using System.IO;

namespace Infrastructure.Logging
{
    public class Logger : ILogger
    {
        #region Constructor Crea carpeta logs si no existe
        private readonly string logFilePath = "Logs/logs.txt";

        public Logger()
        {
            var folder = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }
        #endregion
        #region Metodos para Info y Error
        public void LogInfo(string context, string message, string? additionalData = null)
        {
            Log("INFO", context, message, additionalData);
        }

        public void LogError(string context, string message, string? additionalData = null)
        {
            Log("ERROR", context, message, additionalData);
        }
        #endregion

        #region Creacion o guardado del Log
        private void Log(string level, string context, string message, string? additionalData)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logLine = $"[{timestamp}] [{level}] {context}: {message}";

            if (!string.IsNullOrWhiteSpace(additionalData))
            {
                logLine += $" [{additionalData}]";
            }

            File.AppendAllText(logFilePath, logLine + Environment.NewLine);
        }
        #endregion
    }
}
