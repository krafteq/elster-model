namespace Krafteq.ElsterModel
{
    using LanguageExt;

    delegate Validation<TError, T> Validator<TError, T>(T value);
}