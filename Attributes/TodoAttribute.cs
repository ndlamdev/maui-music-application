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
    private readonly string _task = string.Empty;

    public TodoAttribute()
    {
    }

    public TodoAttribute(string task)
    {
        _task = task;
    }

    public static void PrintTask<T>([CallerMemberName] string? methodName = null)
    {
        var method = typeof(T).GetMethod(methodName ?? "", BindingFlags.NonPublic | BindingFlags.Instance);
        if (method == null) return;
        var attribute = method.GetCustomAttribute<TodoAttribute>();
        if (attribute == null) return;
        Log.Info("TodoAttribute", $"Class: {typeof(T)}\nMethod: {methodName}\nTask message: {attribute._task}");
    }
}