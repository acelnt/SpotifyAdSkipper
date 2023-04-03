using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAdSkipper
{
    internal static partial class Logger
    {
        /// <summary>
        /// The buffer stores the last lines of the logfile so they can be accessed quickly
        /// </summary>
        private class Buffer
        {
            List<string> _buffer = new List<string>();

            int _length = 0;

            readonly int MAX_SIZE;

            /// <summary>
            /// The line in the logfile which the first line of the buffer is a copy of
            /// </summary>
            public int Offset { get; private set; } = 1;

            /// <summary>
            /// Initializes a buffer with a given max number of lines which can be written to it.
            /// </summary>
            /// <param name="maxSize"></param>
            public Buffer(int maxSize)
            {
                MAX_SIZE = maxSize;
            }

            /// <summary>
            /// Writes a line to the buffer, removing the first line if it exceeds the max size.
            /// </summary>
            /// <param name="line"></param>
            public void Write(string line)
            {
                _buffer.Add(line);
                _length += 1;

                if (_length > MAX_SIZE)
                {
                    _buffer.RemoveAt(0);
                    _length -= 1;
                    Offset += 1;
                }
            }

            /// <summary>
            /// Given a line number of the logfile, returns the lines from that line to the end.
            /// If the buffer does not contain that line, returns null. The passed in int is not 
            /// the line number of the buffer, it is the line number of the logfile.
            /// </summary>
            /// <param name="logfileStartLine"></param>
            public List<string> ReadFrom(int logfileStartLine)
            {
                List<string> returnLines;

                // If the line you are trying to read is before what the buffer holds, return null
                if (logfileStartLine < Offset)
                {
                    returnLines = null;
                }
                else
                {
                    // Gets only the part of the buffer which goes from logfileStartLine to the end
                    returnLines = _buffer.Skip(logfileStartLine - Offset).ToList();
                }

                return returnLines;
            }
        }
    }
}
