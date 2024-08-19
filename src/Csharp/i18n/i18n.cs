using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATRIEssentials;
using ATRIEssentialsPluginMainProject.Logger;
using Newtonsoft.Json.Linq;
using Path = System.Path;

namespace ATRIEssentialsPluginMainProject.i18n
{
    public class i18n
    {
       
        private static readonly Dictionary<string, Dictionary<string, string>> lang = new ()
        {
        };

        public static string Plugins_Language { get; private set; } = "en_US";

        public static void InitI18n()
        {
            var currentCultureName = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            if (!lang.Equals(currentCultureName))
            {
                Plugins_Language = "en_US";
            }
            else
            {
                Plugins_Language = currentCultureName;
            }

           ///Todo: 释放语言文件
            if (!Directory.Exists(Path.language))
            {
                Directory.CreateDirectory(Path.language);
                return;
            }
            foreach (var VARIABLE in Directory.GetFiles(Path.language,"*.json"))
            {
                try
                {
                    JObject langsJObject = JObject.Parse(File.ReadAllText(VARIABLE));
                    lang.Add(langsJObject["atri.language"].ToString(),JObjectToDictionary(langsJObject));
                }
                catch (Exception e)
                {
                    logger.error(e);
                }
                
            }
            
        }

        private static Dictionary<string, string> JObjectToDictionary(JObject jbJObject)
        {
            Dictionary<string, string> strs = new();
            foreach (var VARIABLE in jbJObject)
            {
                strs.Add(VARIABLE.Key.ToString(),VARIABLE.Value.ToString());
            }
            return strs;
        }
        public static string Get(string str)
        {
            Dictionary<string, string> strs = new Dictionary<string, string>();
            var tryGetValue = lang.TryGetValue(Plugins_Language, out strs);
            if (!tryGetValue)
            {
                return str;
            }
            else
            {
                return strs[str];
            }
        }

        public static string Get(string str, string language)
        {
            Dictionary<string, string> strs = new Dictionary<string, string>();
            var tryGetValue = lang.TryGetValue(str, out strs);
            if (!tryGetValue)
            {
                return str;
            }
            else
            {
                return strs[str];
            }
        }

    }
}
