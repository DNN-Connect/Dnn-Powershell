using System.IO;

namespace Connect.DNN.Powershell.Common
{
    public class Globals
    {
        public static string ReadFile(string path)
        {
            var res = "";
            if (!File.Exists(path)) { return ""; }
            using (var sr = new StreamReader(path))
            {
                res = sr.ReadToEnd();
            }
            return res;
        }
        public static void SaveString(string path, string contents)
        {
            using (var sw = new StreamWriter(path, false))
            {
                sw.WriteLine(contents);
                sw.Flush();
            }
        }
    }
}
