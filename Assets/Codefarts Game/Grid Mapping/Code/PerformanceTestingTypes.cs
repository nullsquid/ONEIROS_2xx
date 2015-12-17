// <copyright>
//   Copyright (c) 2012 Codefarts
//   All rights reserved.
//   contact@codefarts.com
//   http://www.codefarts.com
// </copyright>

#if PERFORMANCE
namespace Codefarts.GridMapping
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public class PerformanceTestingTypes
    {     
        private static PerformanceTestingTypes singleton;
        private List<Type> types = new List<Type>();

        public static PerformanceTestingTypes Instance
        {
            get
            {
                return singleton ?? (singleton = new PerformanceTestingTypes());
            }
        }

        public static object GetTesting(Type type)
        {
            var performanceTestingType = typeof(PerformanceTesting<>);
            Type[] typeArgs = { type };
            var genericType = performanceTestingType.MakeGenericType(typeArgs);
            return genericType.GetProperty("Instance").GetGetMethod().Invoke(null, null);
        }

        public static string[] GetKeyNames(IEnumerable<Type> getTypes)
        {
            var keys = new List<string>();
            foreach (var type in getTypes)
            {
                keys.AddRange(GetKeyNames(type));
            }

            var names = new string[keys.Count];
            keys.CopyTo(names);
            return names;
        }

        public static string[] GetKeyNames(Type accessorType)
        {
            var performanceTestingType = typeof(PerformanceTesting<>);
            Type[] typeArgs = { accessorType };
            var genericType = performanceTestingType.MakeGenericType(typeArgs);

            var data = genericType.GetProperty("Instance", BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public).GetGetMethod().Invoke(null, null);
            var keysMethod = data.GetType().GetMethod("GetKeys");
            var toConverter = data.GetType().GetProperty("ConvertToStringCallback");
            var func = toConverter.GetGetMethod().Invoke(data, null);
            var invoker = func.GetType().GetMethod("Invoke");
          
            var keys = (IList)keysMethod.Invoke(data, null);
            var names = new string[keys.Count];
            for (var i = 0; i < keys.Count; i++)
            {
                names[i] = invoker.Invoke(func, new[] { keys[i] }) as string;
            }

            return names;
        }

        public static Type[] GetTypes()
        {
            var values = new Type[Instance.types.Count];
            Instance.types.CopyTo(values, 0);
            return values;
        }

        public static void Register<T>()
        {
            var type = typeof(T);
            if (!Instance.types.Contains(type))
            {
                Instance.types.Add(type);
            }
        }
    }
}
#endif