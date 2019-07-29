namespace Krafteq.ElsterModel
{
    using System;
    using LanguageExt;

    static class Extensions
    {
        public static T AssertSome<T>(this Option<T> option) =>
            option.IfNone(() => throw new InvalidOperationException("should be some"));

        public static T AssertRight<L, T>(this Either<L, T> either) =>
            either.IfLeft(() => throw new InvalidOperationException("should be right"));
    }
}