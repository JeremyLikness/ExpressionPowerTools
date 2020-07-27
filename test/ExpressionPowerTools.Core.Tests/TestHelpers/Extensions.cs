using System;
using System.Linq;
using System.Reflection;

namespace ExpressionPowerTools.Core.Tests.TestHelpers
{
    public static class Extensions
    {
        public static MethodInfo MethodWithName(
            this Type type, 
            string name, 
            bool isStatic = false)
        {
            var methods = type.GetMethods(BindingFlags.Public | 
                (isStatic ? BindingFlags.Static : BindingFlags.Instance));
            return methods.FirstOrDefault(m => m.Name == name);
        }

        public static MethodInfo MethodWithNameAndParameterCount(
            this Type type, 
            string name, 
            int parameterCount, 
            bool isStatic = false)
        {
            var methods = type.GetMethods(BindingFlags.Public |
                (isStatic ? BindingFlags.Static : BindingFlags.Instance));
            return methods.FirstOrDefault(m => m.Name == name && m.GetParameters().Count() == parameterCount);
        }
    }
}
