using System;

namespace uwu.Library;

public static class StringExtensions
{
    public static string Optional(this string _, bool pred, ReadOnlySpan<char> ifTrue, ReadOnlySpan<char> ifFalse = default)
        => $"{(pred ? ifTrue : ifFalse)}";

    public static string OptionalPrefix(this string s, bool pred, ReadOnlySpan<char> ifTrue, ReadOnlySpan<char> ifFalse = default)
        => $"{s.Optional(pred, ifTrue, ifFalse)}{s}";

    public static string OptionalSuffix(this string s, bool pred, ReadOnlySpan<char> ifTrue, ReadOnlySpan<char> ifFalse = default)
        => $"{s}{s.Optional(pred, ifTrue, ifFalse)}";
}
