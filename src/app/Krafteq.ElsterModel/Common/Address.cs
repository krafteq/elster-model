namespace Krafteq.ElsterModel.Common
{
    using System;
    using LanguageExt;

    public class Address
    {
        public static readonly Address Empty = new Address();

        ForeignAddress foreign;
        DomesticAddress domestic;
        
        Address(){}

        public static Address Foreign(ForeignAddress foreignAddress) =>
            new Address {foreign = foreignAddress};

        public static Address Domestic(DomesticAddress domesticAddress) =>
            new Address {domestic = domesticAddress};

        public T Match<T>(
            Func<DomesticAddress, T> whenDomestic,
            Func<ForeignAddress, T> whenForeign,
            Func<T> whenEmpty
        )
        {
            if (this.foreign != null)
                return whenForeign(this.foreign);

            if (this.domestic != null)
                return whenDomestic(this.domestic);

            return whenEmpty();
        }
    }

    public class ForeignAddress
    {
        public ZipForeign ZipForeign { get; }
        public City City { get; }
        public Country Country { get; }
        public Option<Street> Street { get; }
        public Option<Street2> AdditionalAddress { get; }
        public Option<int> HouseNumber { get; }
        public Option<AdditionalHouseNumber> AdditionalHouseNumber { get; }

        public ForeignAddress(
            ZipForeign zipForeign, 
            City city, 
            Country country, 
            Option<Street> street, 
            Option<Street2> additionalAddress,
            Option<int> houseNumber, 
            Option<AdditionalHouseNumber> additionalHouseNumber)
        {
            this.ZipForeign = zipForeign ?? throw new ArgumentNullException(nameof(zipForeign));
            this.City = city ?? throw new ArgumentNullException(nameof(city));
            this.Country = country ?? throw new ArgumentNullException(nameof(country));
            this.Street = street;
            this.AdditionalAddress = additionalAddress;
            this.HouseNumber = houseNumber;
            this.AdditionalHouseNumber = additionalHouseNumber;
        }
    }

    public class DomesticAddress
    {
        public Zip Zip { get; }
        public City City { get; }
        public Option<Street> Street { get; }
        public Option<Street2> AdditionalAddress { get; }
        public Option<int> HouseNumber { get; }
        public Option<AdditionalHouseNumber> AdditionalHouseNumber { get; }
        
        public DomesticAddress(
            Zip zip, 
            City city, 
            Option<Street> street, 
            Option<Street2> additionalAddress, 
            Option<int> houseNumber, 
            Option<AdditionalHouseNumber> additionalHouseNumber)
        {
            this.Zip = zip ?? throw new ArgumentNullException(nameof(zip));
            this.City = city ?? throw new ArgumentNullException(nameof(city));
            this.Street = street;
            this.AdditionalAddress = additionalAddress;
            this.HouseNumber = houseNumber;
            this.AdditionalHouseNumber = additionalHouseNumber;
        }
    }
}