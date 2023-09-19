using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using RGiesecke.DllExport;

namespace MakeFile
{
    public class DLLFuncs
    {
        [DllExport("RVExtension", CallingConvention = CallingConvention.StdCall)]
        public static void RVExtension(StringBuilder output, int outputSize, string function)
        {
            int index = function.IndexOf('|');
            string name = function.Substring(0, index);
            string data = function.Substring(index + 1);
            output.Append(SaveFile(name, data));
        }
        private static string SaveFile(string path, string data)
        {
            File.AppendAllText(path, data, Encoding.GetEncoding(1252));

            return $"{path} done!";
        }
    }
}
