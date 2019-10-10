namespace Krafteq.ElsterModel.Processes.Usta
{
    using System;
    using Krafteq.ElsterModel.Common;
    using LanguageExt;

    public class DataSupplier
    {
        public DataSupplierName Name { get; }
        public DataSupplierStreet Street { get; }
        public DataSupplierZip Zip { get; }
        public DataSupplierCity City { get; }
        public Option<Phone> Phone { get; }
        public Option<Email> Email { get; }

        public DataSupplier(
            DataSupplierName name, 
            DataSupplierStreet street,
            DataSupplierZip zip,
            DataSupplierCity city,
            Option<Phone> phone, 
            Option<Email> email)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Street = street ?? throw new ArgumentNullException(nameof(street));
            this.Zip = zip ?? throw new ArgumentNullException(nameof(zip));
            this.City = city ?? throw new ArgumentNullException(nameof(city));
            this.Phone = phone;
            this.Email = email;
        }
    }
}