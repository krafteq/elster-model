namespace Krafteq.ElsterModel.Common
{
    using System;
    using LanguageExt;

    public class AccountantInfo
    {
        public static readonly AccountantInfo Empty = new AccountantInfo(Prelude.None,
            FullName.Empty, Address.Empty, POBox.Empty, ContactInfo.Empty);
        
        public Option<CompanyName> Name { get; }
        public FullName PersonName { get; }
        public Address Address { get; }
        public POBox POBox { get; }
        public ContactInfo ContactInfo { get; }

        public AccountantInfo(Option<CompanyName> name, FullName personName, Address address, POBox poBox, ContactInfo contactInfo)
        {
            this.Name = name;
            this.PersonName = personName ?? throw new ArgumentNullException(nameof(personName));
            this.Address = address ?? throw new ArgumentNullException(nameof(address));
            this.POBox = poBox ?? throw new ArgumentNullException(nameof(poBox));
            this.ContactInfo = contactInfo ?? throw new ArgumentNullException(nameof(contactInfo));
        }
    }
}