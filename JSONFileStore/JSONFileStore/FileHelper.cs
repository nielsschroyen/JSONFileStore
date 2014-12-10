using System.IO;

namespace JSONFileStore
{
    public static class FileHelper
    {
        public static bool Exists(string file)
        {
            return File.Exists(file);
        }

        public static string Read(string file)
        {
            return File.ReadAllText(file);
        }

        public static void Write(string file, string content)
        {
            File.WriteAllText(file, content);
        }
    }
}