using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Logger
{
    class Logger
    {

        public static StreamWriter stream;
        
        public static Config Configuration;

        private static StringBuilder logMessageBuilder = new StringBuilder();

        /*
         * Add a way to access log from inside of the dll (no class calling).
         * Create a log file each day at 00:00.
         * Set default log location to application directory.
         */

        public Logger(Config configuration)
        {
            Configuration = configuration;
            using (stream = new StreamWriter(new FileStream(Configuration.FilePath, FileMode.Append, FileAccess.Write)));
        }

        /// <summary>
        /// Logs a info message.
        /// </summary>
        /// <param name="message">The log message.</param>
        public void Info<T>(T message)
        {
            if (Configuration.InfoEnabled)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Log(LogLevel.INFO, message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Logs a warn message.
        /// </summary>
        /// <param name="message">The log message.</param>
        public void Warn<T>(T message)
        {
            if (Configuration.WarnEnabled)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Log(LogLevel.WARN, message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Logs a error message.
        /// </summary>
        /// <param name="message">The log message.</param>
        public void Error<T>(T message)
        {
            if (Configuration.ErrorEnabled)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Log(LogLevel.ERROR, message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Logs a fatal message.
        /// </summary>
        /// <param name="message">The log message.</param>
        public void Fatal<T>(T message)
        {
            if (Configuration.FatalEnabled)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Log(LogLevel.FATAL, message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Logs a trace message.
        /// </summary>
        /// <param name="message">The log message.</param>
        public void Trace<T>(T message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Log(LogLevel.TRACE, message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The log message.</param>
        public void Debug<T>(T message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Log(LogLevel.DEBUG, message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Outputs the message to the console and log file.
        /// </summary>
        /// <param name="logLevel">The log level of the message.</param>
        /// <param name="message">The log message.</param>
        private void Log<T>(LogLevel logLevel, T message)
        {
            logMessageBuilder.Clear();
            logMessageBuilder.Append(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]|"));
            logMessageBuilder.Append(Process.GetCurrentProcess().ProcessName +"|");
            logMessageBuilder.Append(logLevel.ToString() + ": ");
            logMessageBuilder.Append(message);
            Console.WriteLine(logMessageBuilder.ToString());
            stream.WriteLine(logMessageBuilder.ToString());
            stream.Flush();
        }

    }
}
