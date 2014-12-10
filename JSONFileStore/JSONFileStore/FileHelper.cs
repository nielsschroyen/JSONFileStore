namespace JSONFileStore
{
    public static class FileHelper
    {
        public static string Read(string file)
        {
            return System.IO.File.ReadAllText(file);
        }

        public static void Write(string file, string content)
        {
            System.IO.File.WriteAllText(file, content);
        }
    }
}