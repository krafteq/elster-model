namespace Krafteq.ElsterModel.Processes.Usta.Ustva
{
    using System.Linq;
    using LanguageExt;
    using static LanguageExt.Prelude;

    public class Kz09
    {
        public ManufacturerId ManufacturerId { get; }
        public Option<Kz09PartialString> ConsultantName { get; }
        public Option<Kz09PartialString> Profession { get; }
        public Option<Kz09PartialString> PhonePrefix { get; }
        public Option<Kz09PartialString> Phone { get; }
        public Option<Kz09PartialString> TenantName { get; }
        
        public string Formatted { get; private set; }

        public Kz09(
            ManufacturerId manufacturerId, 
            Option<Kz09PartialString> consultantName,
            Option<Kz09PartialString> profession, 
            Option<Kz09PartialString> phonePrefix, 
            Option<Kz09PartialString> phone, 
            Option<Kz09PartialString> tenantName)
        {
            this.ManufacturerId = manufacturerId;
            this.ConsultantName = consultantName;
            this.Profession = profession;
            this.PhonePrefix = phonePrefix;
            this.Phone = phone;
            this.TenantName = tenantName;
            
            this.FormatValue();
        }

        void FormatValue()
        {
            var others = List(
                this.ConsultantName,
                this.Profession,
                this.PhonePrefix,
                this.Phone,
                this.TenantName
            ).Map(x => x.Map(y => y.Value));

            var othersPresented = others.Somes().Any();
            if (!othersPresented)
            {
                this.Formatted = this.ManufacturerId.Value;
                return;
            }

            var parts = List(this.ManufacturerId.Value) + others.Map(x => x.IfNone(""));
            this.Formatted = string.Join("*", parts);
        }

        public static Kz09 Manufacturer(ManufacturerId id) =>
            new Kz09(id, None, None, None, None, None);

        public override string ToString() => this.Formatted;
    }

    public class ManufacturerId : NewType<ManufacturerId, string>
    {
        static readonly StringValidator Validator = StringValidator.Exact(5);
        
        public static Either<Error, ManufacturerId> Create(string value) =>
            Validate(value).Map(x => new ManufacturerId(x));
        
        ManufacturerId(string value) : base(value)
        {
        }


        static Either<Error, string> Validate(string value) =>
            Validator.Validate(value)
                .Bind(v => Optional(v)
                    .Filter(x => !x.Contains("*"))
                    .ToEither(() => new Error("should not contain '*'")));
    }
    
    public class Kz09PartialString : NewType<Kz09PartialString, string>
    {
        static readonly StringValidator Validator = StringValidator.Max(85);
        
        public static Either<Error, Kz09PartialString> Create(string value) =>
            Validate(value).Map(x => new Kz09PartialString(x));
        
        Kz09PartialString(string value) : base(value)
        {
        }
        
        static Either<Error, string> Validate(string value) =>
            Validator.Validate(value)
                .Bind(v => Optional(v)
                    .Filter(x => !x.Contains("*"))
                    .ToEither(() => new Error("should not contain '*'")));
    }
}