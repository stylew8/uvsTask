using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interfaces;

namespace BL.Implementations
{
    public class Converter : IConverter
    {
        /// <summary>
        /// Siam uzdaviniui, pagalvojau, kad sis Convertas veikia kaip papildomas validation
        /// </summary>
        public Dictionary<string, string> ConvertStringArrayToDictionary(string[] args)
        {
            var argsDictionary = new Dictionary<string, string>();

            for (int i = 1; i < args.Length; i += 2)
            {
                if (args[i+1] != null)
                {
                    argsDictionary[args[i]] = args[i + 1];
                }
            }

            return argsDictionary;
        }
    }
}
