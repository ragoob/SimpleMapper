using System;
using System.Reflection;
namespace Mapper
{
    public static class MapperExtention
    {
        public static V Map<T,V>(this T source)
        {
            var instance = Activator.CreateInstance<V>();
            foreach (var item in source.GetType().GetProperties())
            {
                if (instance.GetType().GetProperty(item.Name) != null)
                {
                    var prop = instance.GetType().GetProperty(item.Name);
                    prop.SetValue(item.GetValue(source), instance);
                }
            }
            return instance;

        }

        
    }
}
