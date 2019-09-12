namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class FullName
    {
        public static readonly FullName Empty = new FullName(Prelude.None, Prelude.None);
        
        public Option<FirstName> FirstName { get; }
        public Option<LastName> LastName { get; }
//        public string Title { get; set; }
//        public string MiddleName { get; set; }

        public FullName(Option<FirstName> firstName, Option<LastName> lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}