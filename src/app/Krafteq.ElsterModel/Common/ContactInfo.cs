namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class ContactInfo
    {
        public static readonly ContactInfo Empty = new ContactInfo(Prelude.None, Prelude.None);
        public Option<Phone> Phone { get; }
        public Option<Email> Email { get; }

        public ContactInfo(Option<Phone> phone, Option<Email> email)
        {
            this.Phone = phone;
            this.Email = email;
        }
    }
}