using System;
using System.Collections.Generic;

namespace Assets.Scripts.MainLogic
{
    class GameContext
    {
        private static Dictionary<string, object> InstanceByString = new Dictionary<string, object>();        

        public static void Register(string key, object instance)
        {
            InstanceByString.Add(key, instance);
        }

        public static T GetInstance<T>(string key) where T : class
        {
            if (InstanceByString.ContainsKey(key))
                return InstanceByString[key] as T;
            return null;
        }        
    }
}
