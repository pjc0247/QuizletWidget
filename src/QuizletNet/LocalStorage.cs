using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace QuizletNet
{
    class LocalStorage
    {
        private static Dictionary<string, object> storage;

        private static string FilePath = "quizlet_api";

        public static void Reset()
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);
        }

        public static void Set(string key, object value)
        {
            storage[key] = value;
            Save();
        }
        public static object Get(string key)
        {
            if (storage.ContainsKey(key) == false)
                return null;

            return storage[key];
        }

        public static void Load()
        {
            try
            {
                var json = File.ReadAllText(FilePath);

                storage = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
            catch(Exception e)
            {
                storage = new Dictionary<string, object>();
            }
        }
        private static void Save()
        {
            try
            {
                var json = JsonConvert.SerializeObject(storage);

                File.WriteAllText(FilePath, json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
