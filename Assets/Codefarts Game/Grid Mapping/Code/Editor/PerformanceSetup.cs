/*
<copyright>
  Copyright (c) 2012 Codefarts
  All rights reserved.
  contact@codefarts.com
  http://www.codefarts.com
</copyright>
*/
#if PERFORMANCE
namespace Codefarts.GridMapping.Editor
{
    using System;
    using System.Reflection;

    using UnityEditor;

    using UnityEngine;

    /// <summary>
    /// Provides performance inspection menu items that integrate into unity's menu.
    /// </summary>
    [InitializeOnLoad]
    public class PerformanceSetup
    {
        /// <summary>
        /// Initializes static members of the <see cref="PerformanceSetup"/> class.
        /// </summary>
        static PerformanceSetup()
        {
            var sPerf = PerformanceTesting<string>.Instance;
            sPerf.ConvertFromStringCallback = (x) => x;
            sPerf.ConvertToStringCallback = (x) => x;

            var idPerf = PerformanceTesting<PerformanceID>.Instance;
            idPerf.ConvertFromStringCallback = (x) => (PerformanceID)Enum.Parse(typeof(PerformanceID), x);
            idPerf.ConvertToStringCallback = (x) => Enum.GetName(typeof(PerformanceID), x);
                                                                                       
            idPerf.Create((PerformanceID[])Enum.GetValues(typeof(PerformanceID)));
        }

        /// <summary>
        /// Provides a menu to allow developer to report performance.                                              
        /// </summary>
        [MenuItem("Window/Codefarts/Performance/Report")]
        public static void ReportPerformance()
        {
            ReportPerformanceTimes();
        }

        /// <summary>
        /// If the PERFORMANCE symbol is available will report the performance metric information out to the console.
        /// </summary>
        public static void ReportPerformanceTimes()
        {
            var result = string.Empty;
            foreach (var type in PerformanceTestingTypes.GetTypes())
            {
                var performanceTestingType = typeof(PerformanceTesting<>);
                Type[] typeArgs = { type };
                var genericType = performanceTestingType.MakeGenericType(typeArgs);

                var data = genericType.GetProperty("Instance", BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public).GetGetMethod().Invoke(null, null);
                var totalMilli = data.GetType().GetMethod("TotalMilliseconds", new[] { type });
                var avgMilli = data.GetType().GetMethod("AverageMilliseconds", new[] { type });
                var startCount = data.GetType().GetMethod("GetStartCount", new[] { type });
                var fromConverter = data.GetType().GetProperty("ConvertFromStringCallback");
                var func = fromConverter.GetGetMethod().Invoke(data, null);
                var invoker = func.GetType().GetMethod("Invoke");

                var keyNames = PerformanceTestingTypes.GetKeyNames(type);

                long totalSumMilliseconds = 0;
                foreach (var name in keyNames)
                {
                    // var key = PerformanceTestingTypes.ConvertKey(name);
                    //  var key = fromConverter.Invoke(data, new[] { name });
                    var key = invoker.Invoke(func, new[] { name });// fromConverter.GetValue(name, null);
                    //  var key = fromConverter.GetValue(name, null);
                    var totalMilliResultValue = totalMilli.Invoke(data, new[] { key });
                    totalSumMilliseconds += (long)totalMilliResultValue;
                    result += string.Format("{0} - Total: {1}ms Average: {2} Count: {3}\r\n", name, totalMilliResultValue, avgMilli.Invoke(data, new[] { key }), startCount.Invoke(data, new[] { key }));
                }

                result += string.Format("Total Performance Times - Total: {0}ms\r\n", totalSumMilliseconds);
            }

            Debug.Log(result);
        }

        /// <summary>
        /// Provides a menu to allow developer to reset performance numbers.                                              
        /// </summary>
        [MenuItem("Window/Codefarts/Performance/Reset")]
        public static void ResetPerformance()
        {
            PerformanceTesting<int>.ResetAll(PerformanceTestingTypes.GetTypes(), true);
        }
    }
}
#endif