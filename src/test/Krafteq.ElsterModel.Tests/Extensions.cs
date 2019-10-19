namespace Krafteq.ElsterModel.Tests
{
    using System;
    using FluentAssertions;
    using LanguageExt;
    
    using static LanguageExt.Prelude;

    public static class Extensions
    {
        public static R resolve_right<L, R>(this Either<L, R> either)
        {
            if (either.IsLeft)
                throw new InvalidOperationException($"the right object is expected. got {either}");

            return either.IfLeft(default(R));
        }

        public static L resolve_left<L, R>(this Either<L, R> either)
        {
            if (either.IsRight)
                throw new InvalidOperationException($"the left object is expected. got {either}");

            return either.IfRight(default(L));
        }

        public static R should_be_right<L, R>(this Either<L, R> either)
        {
            return either.resolve_right();
        }

        public static L should_be_left<L, R>(this Either<L, R> either)
        {
            return either.resolve_left();
        }

        public static void ShouldBeNone<T>(this Option<T> option)
        {
            option.IsNone.Should().BeTrue();
        }

        public static T ShouldBeSome<T>(this Option<T> option)
        {
            option.IsSome.Should().BeTrue();
            return option.IfNone(default(T));
        }
        
        public static T should_be_valid<L, T>(this Validation<L, T> either) =>
            either.IfFail(f => throw new InvalidOperationException("should be right"));
        
        public static Lst<L> should_fail<L, T>(this Validation<L, T> either) =>
            toList(either
                .IfSuccess(f => throw new InvalidOperationException("should be right")));
    }
}