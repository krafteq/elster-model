namespace Krafteq.ElsterModel.ValidationCore
{
    using LanguageExt;

    delegate Validation<TError, T> Validator<TError, T>(T value);
}