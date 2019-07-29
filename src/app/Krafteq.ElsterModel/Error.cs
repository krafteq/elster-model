namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class Error : NewType<Error, string>
    {
        public Error(string value) : base(value)
        {
        }
    }
}