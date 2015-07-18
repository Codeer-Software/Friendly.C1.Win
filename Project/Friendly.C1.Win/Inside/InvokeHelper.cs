using System;
using System.Collections.Generic;
using System.Text;

namespace Friendly.C1.Win.Inside
{
    static class InvokeHelper
    {
        internal static object Invoke(object obj, string name)
        {
            return obj.GetType().GetMethod(name, new Type[] { }).Invoke(obj, new object[] { });
        }
        internal static object Invoke<T0>(object obj, string name, T0 t0)
        {
            return obj.GetType().GetMethod(name, new Type[] { typeof(T0) }).
                Invoke(obj, new object[] { t0 });
        }
        internal static object Invoke<T0, T1>(object obj, string name, T0 t0, T1 t1)
        {
            return obj.GetType().GetMethod(name, new Type[] { typeof(T0), typeof(T1) }).
                Invoke(obj, new object[] { t0, t1 });
        }
        internal static object Invoke<T0, T1, T2, T3>(object obj, string name, T0 t0, T1 t1, T2 t2, T3 t3)
        {
            return obj.GetType().GetMethod(name, new Type[] { typeof(T0), typeof(T1), typeof(T2), typeof(T3) }).
                Invoke(obj, new object[] { t0, t1, t2, t3 });
        }
    }
}
