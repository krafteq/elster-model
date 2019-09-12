namespace Krafteq.ElsterModel.Common
{
    using System;

    public class CompanyInfo
    {
        public CompanyName CompanyName { get; }
        public FullName PersonName { get; }
        public Address Address { get; }
        public POBox POBox { get; }
        public ContactInfo ContactInfo { get; }

        public CompanyInfo(CompanyName companyName, FullName personName, Address address, POBox poBox, ContactInfo contactInfo)
        {
            this.CompanyName = companyName ?? throw new ArgumentNullException(nameof(companyName));
            this.PersonName = personName ?? throw new ArgumentNullException(nameof(personName));
            this.Address = address ?? throw new ArgumentNullException(nameof(address));
            this.POBox = poBox ?? throw new ArgumentNullException(nameof(poBox));
            this.ContactInfo = contactInfo ?? throw new ArgumentNullException(nameof(contactInfo));
        }
    }
}