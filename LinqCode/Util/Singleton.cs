using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode.Util
{
    public class BaseSingleton
    {
        public static IDictionary<Type, object> AllSingletons { get; }

        static BaseSingleton()
        {
            AllSingletons = new Dictionary<Type, object>();
        }
    }

    public class Singleton<T> : BaseSingleton
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
                BaseSingleton.AllSingletons[typeof(T)] = value;
            }
        }
    }
}
