using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace SpotifyAdSkipper
{
    /// <summary>
    /// Provides logging functionality. Stores the log as a list of strings
    /// </summary>
    internal static partial class Logger
    {
        const string LOGFILE_PATH = "log.log";

        // the buffer is used to store the last lines of the log file so that they can be accessed
        // in a ReadFromLine operation.
        static Buffer _buffer = new Buffer(1000);

        public static int Length { get; private set; } = 0;

        /// <summary>
        /// Empties the log
        /// </summary>
        public static void Clear()
        {
            File.WriteAllText(LOGFILE_PATH, string.Empty);
            Length = 0;
            _buffer = new Buffer(1000);
        }

        /// <summary>
        /// Writes the message to the log with the current time.
        /// </summary>
        /// <param name="message"></param>
        public static void Write(string message) 
        {
            DateTime currentTime = DateTime.Now;
            string line = $"[{currentTime.ToString("HH:mm:ss.fff")}] {message}";

            using (StreamWriter streamWriter = new StreamWriter(LOGFILE_PATH, true))
            {
                streamWriter.WriteLine(line);
                Length += 1;
            }

            _buffer.Write(line);
        }

        /// <summary>
        /// Returns a list of every line in the logfile, or null if the logfile does
        /// not exist
        /// </summary>
        /// <returns></returns>
        public static List<string> Read()
        {
            List<string> lines;
            try 
            {
                lines = File.ReadAllLines(LOGFILE_PATH).ToList();
            } catch
            {
                lines = null;
            }
            return lines;
        }

        /// <summary>
        /// Returns a list of lines in the logfile, starting from the line startLine and
        /// going until the end of the logfile. Will use the buffer which stores last 1000
        /// lines if appropriate, allowing for faster reading.
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadFromLine(int startLine)
        {
            List<string> lines = _buffer.ReadFrom(startLine);
            
            if (lines == null)
            {
                lines = ReadFromFileFromLine(startLine);
            }
            
            return lines;
        }

        /// <summary>
        /// Returns a list of lines in the logfile, starting from the line startLine and
        /// going until the end of the logfile, by reading from the file. Use ReadFromLine
        /// to benefit from the the buffer, which will allow for faster reading if you
        /// are reading fewer lines.
        /// </summary>
        /// <param name="startLine"></param>
        /// <returns></returns>
        public static List<string> ReadFromFileFromLine(int startLine)
        {
            List<string> lines = new List<string>();
            
            try
            {
                using (StreamReader reader = new StreamReader(LOGFILE_PATH))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        lineNumber++;

                        if (lineNumber >= startLine)
                        {
                            lines.Add(line);
                        }
                    }
                }
            }
            catch
            {
                lines = null;
            }

            return lines;
        }
    }
}
