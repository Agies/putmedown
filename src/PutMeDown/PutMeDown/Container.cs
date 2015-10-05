using System;
using System.Collections.Generic;

namespace PutMeDown
{
    public class Container
    {
        private static readonly object SyncObject = new object();
        
        private static Container _instance;
        public static Container Instance
        {
            get
            {
                lock (SyncObject)
                {
                    if (_instance == null)
                    {
                        _instance = new Container();
                    }
                }
                return _instance;
            }
        }

        public Container()
        {
            Hash = new Dictionary<Type, object>();
        }

        public T GetInstance<T>()
        {
            return (T)Hash[typeof (T)];
        }

        public void Register<T>(T instance)
        {
            Hash[typeof (T)] = instance;
        }

        public Dictionary<Type, Object> Hash { get; set; }
    }
}