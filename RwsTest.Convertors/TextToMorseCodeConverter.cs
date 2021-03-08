using RwsTest.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RwsTest.Convertors
{
    public class TextToMorseCodeConverter : IFormatConverter
    {
        /// <summary>
        /// Converts text to a Morse code
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Convert(string input)
        {
            var dict = new Dictionary<char, string> {
                { 'a', ".-" },
                { 'b', "-..." },
                { 'c', "-.-." },
                { 'd', "-.." },
                { 'e', "." },
                { 'f', "..-." },
                { 'g', "--." },
                { 'h', "...." },
                { 'i', ".." },
                { 'j', ".---" },
                { 'k', "-.-" },
                { 'l', ".-.." },
                { 'm', "--" },
                { 'n', "-." },
                { 'o', "---" },
                { 'p', ".--." },
                { 'q', "--.-" },
                { 'r', ".-." },
                { 's', "..." },
                { 't', "-" },
                { 'u', "..-" },
                { 'v', "...-" },
                { 'w', ".--" },
                { 'x', "-..-" },
                { 'y', "-.--" },
                { 'z', "--.." },
            };

            input = input.Trim().ToLowerInvariant();
            var retval = string.Concat(input.Select(x => dict.ContainsKey(x) ? dict[x] + "/" : ""));

            return retval;
        }
    }
}
