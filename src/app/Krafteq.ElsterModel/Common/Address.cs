namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class Address
    {
        public static readonly Address Empty = new Address(Prelude.None, Prelude.None, Prelude.None, Prelude.None, Prelude.None, Prelude.None, Prelude.None, Prelude.None);
        
        public Option<Street> Street { get; }
        public Option<Street2> AdditionalAddress { get; }
        public Option<int> HouseNumber { get; }
        public Option<AdditionalHouseNumber> AdditionalHouseNumber { get; }
        public Option<Zip> Zip { get; }
        public Option<ZipForeign> ZipForeign { get; }
        public Option<City> City { get; }
        public Option<Country> Country { get; }

        public Address(
            Option<Street> street, 
            Option<Street2> additionalAddress, 
            Option<int> houseNumber, 
            Option<AdditionalHouseNumber> additionalHouseNumber, 
            Option<Zip> zip, 
            Option<ZipForeign> zipForeign, 
            Option<City> city, 
            Option<Country> country)
        {
            this.Street = street;
            this.AdditionalAddress = additionalAddress;
            this.HouseNumber = houseNumber;
            this.AdditionalHouseNumber = additionalHouseNumber;
            this.Zip = zip;
            this.ZipForeign = zipForeign;
            this.City = city;
            this.Country = country;
        }
    }
}