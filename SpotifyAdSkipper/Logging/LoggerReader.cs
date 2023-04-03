using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAdSkipper
{
    internal class LoggerReader
    {

        private int _lastLineRead = 0;

        /// <summary>
        /// Returns the lines written to the log since the last call of Next
        /// </summary>
        /// <returns></returns>
        public List<string> NextLines() 
        {
            List<string> result = Logger.ReadFromLine(_lastLineRead + 1);
            _lastLineRead = Logger.Length;
            return result;
        }
    }
}