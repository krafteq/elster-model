namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class Quarter : NewType<Quarter, int>
    {
        Quarter(int value) : base(value)
        {
        }

        public static Option<Quarter> Create(int value)
        {
            if (value < 1 || value > 4)
                return Prelude.None;

            return new Quarter(value);
        }
    }
}