using System.IO;
using UnityEngine;
namespace Asteroids.UnitFactory
{
    public sealed class JsonData<T> : IData<T>
    {
        private readonly string _path;
        public JsonData(string path) 
        {
            _path = path;
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
        }
        public void Save(T data, string fileName = null)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(Path.Combine(_path, fileName), str);
        }
        public T Load(string fileName = null)
        {
            var file = Path.Combine(_path, fileName);
            if (!File.Exists(file)) return default(T);
            var str = File.ReadAllText(file);
            return JsonUtility.FromJson<T>(str);
        }
    }
}
