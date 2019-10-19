namespace Krafteq.ElsterModel.ValidationCore
{
    using LanguageExt;

    static class Validators
    {
        public static Validator<TError, T> All<TError, T>(params Validator<TError, T>[] validators) =>
            v => validators.Fold((Validation<TError, T>) v, (state, validator) =>
                state | validator(v)
            );
    }
}