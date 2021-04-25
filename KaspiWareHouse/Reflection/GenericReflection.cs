using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KaspiWareHouse.Reflection
{
    public class GenericReflection
    {
        public static void GetGenericClasses()
        {
            var path = @"C:\Program Files (x86)\dotnet\shared\Microsoft.NETCore.App\3.1.14\System.Collections.dll";
            var types = Assembly.LoadFrom(path).GetTypes();
            var res = types.Where(type => type.FullName.Contains("System.Collections.Generic") && type.IsClass && type.IsGenericType).ToList();
        }

        public static Type[] GetStringInterfaces()
        {
            return typeof(string).GetInterfaces();
        }
    }
}
