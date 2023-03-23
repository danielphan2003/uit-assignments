using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SkiaSharp;

namespace student_management
{
    public static class State
    {
        private static Dictionary<string, string> _cache = new();

        public static string? Get (string key)
        {
            return _cache.TryGetValue(key, out _) ? _cache[key] : null;
        }

        public static void Set (string key, string value)
        {
            _cache.Add (key, value);
        }
    }
}
