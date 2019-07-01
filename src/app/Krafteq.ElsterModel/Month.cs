namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class Month : NewType<Month, int>
    {
        Month(int value) : base(value)
        {
        }

        public static Option<Month> Create(int value)
        {
            if (value < 1 || value > 12)
                return Prelude.None;

            return new Month(value);
        }
    }
}