namespace Krafteq.ElsterModel
{
    using System;
    using LanguageExt;

    static class Extensions
    {
        public static T AssertSome<T>(this Option<T> option) =>
            option.IfNone(() => throw new InvalidOperationException("should be some"));
    }
}