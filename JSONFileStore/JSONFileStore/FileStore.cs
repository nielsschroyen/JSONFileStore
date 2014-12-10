using Newtonsoft.Json;

namespace JSONFileStore
{
    public class FileStore
    {
        private readonly string _Directory;
        private readonly string _FileName;

        public FileStore(string directory, string fileName)
        {
            _Directory = directory;
            _FileName = fileName;
        }

        /// <summary>
        /// Reads the object from the file.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public T Read<T>()
        {
            var json = FileHelper.Read(GetFullFileName());
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Writes the properties of the object to the file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object to write.</param>
        public void Write<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            FileHelper.Write(GetFullFileName(), json);
        }

        private string GetFullFileName()
        {
            return _Directory + "/" + _FileName;
        }
    }
}