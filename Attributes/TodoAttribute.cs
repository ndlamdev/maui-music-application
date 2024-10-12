using System.Reflection;
using System.Runtime.CompilerServices;
using Android.Util;
using AndroidX.Core.Graphics.Drawable;
using AndroidX.Navigation;

namespace maui_music_application.Attributes;

[AttributeUsage(AttributeTargets.Method,
    AllowMultiple = true)
]
public class TodoAttribute : Attribute
{
    public TodoAttribute()
    {
    }

    public TodoAttribute(string task)
    {
        Log.Info("TodoAttribute", task);
    }

    public static void PrintTask<T>([CallerMemberName] string? methodName = null)
    {
        var method = typeof(T).GetMethod(methodName ?? "", BindingFlags.NonPublic | BindingFlags.Instance);
        if (method == null) return;
        method.GetCustomAttribute<TodoAttribute>();
    }
}
