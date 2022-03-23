using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOPTest.API.Utilities
{
    public class Singleton<T> where T : class, new()
    {
        private Singleton() { }

        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        public static T Instance { get { return instance.Value; } }
    }
}