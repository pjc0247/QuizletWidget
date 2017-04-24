using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using QuizletNet;

namespace QuizletWidget.Config
{
    partial class AppConfig
    {
        public static AppConfig GlobalConfig { get; private set; }

        private static string ConfigPath 
            => "config" + Quizlet.Username;

        public static void Save()
        {
            var json = JsonConvert.SerializeObject(GlobalConfig);
            File.WriteAllText(ConfigPath, json);
        }
        public static void Load()
        {
            try
            {
                var json = File.ReadAllText(ConfigPath);
                GlobalConfig = JsonConvert.DeserializeObject<AppConfig>(json);
            }
            catch (Exception e)
            {
                GlobalConfig = new AppConfig();
            }
        }
    }
}
