namespace Krafteq.ElsterModel
{
    using System;
    using System.Collections.Generic;
    using LanguageExt;

    public class Bundesland : NewType<Bundesland, string>
    {
        static readonly Dictionary<string, Bundesland> all
            = new Dictionary<string, Bundesland>(StringComparer.InvariantCultureIgnoreCase);

        public static readonly Bundesland BadenWuerttemberg = Create("BW",
            TaxNumberMask("FFBBB/UUUUP", "28FF0BBBUUUUP"));

        public static readonly Bundesland Bayern = Create("BY",
            TaxNumberMask("FFF/BBB/UUUUP", "9FFF0BBBUUUUP"));

        public static readonly Bundesland Berlin = Create("BE",
            TaxNumberMask("FF/BBB/UUUUP", "11FF0BBBUUUUP"));

        public static readonly Bundesland Brandenburg = Create("BR",
            TaxNumberMask("FFF/BBB/UUUUP", "3FFF0BBBUUUUP"));

        public static readonly Bundesland Bremen = Create("HB",
            TaxNumberMask("FF BBB UUUUP", "24FF0BBBUUUUP"));

        public static readonly Bundesland Hamburg = Create("HH",
            TaxNumberMask("FF/BBB/UUUUP", "22FF0BBBUUUUP"));

        public static readonly Bundesland Hessen = Create("HE",
            TaxNumberMask("0FF BBB UUUUP", "26FF0BBBUUUUP"));

        public static readonly Bundesland MacklenburgVorpommern = Create("MV",
            TaxNumberMask("FFF/BBB/UUUUP", "4FFF0BBBUUUUP"));

        public static readonly Bundesland Niedersachsen = Create("NI",
            TaxNumberMask("FF/BBB/UUUUP", "23FF0BBBUUUUP"));

        public static readonly Bundesland NordrheinWestfalen = Create("NW",
            TaxNumberMask("FFF/BBBB/UUUP", "5FFF0BBBBUUUP"));

        public static readonly Bundesland RheinlandPfalz = Create("RP",
            TaxNumberMask("FF/BBB/UUUUP", "27FF0BBBUUUUP"));

        public static readonly Bundesland Saarland = Create("SL",
            TaxNumberMask("FFF/BBB/UUUUP", "1FFF0BBBUUUUP"));

        public static readonly Bundesland Sachsen = Create("SN",
            TaxNumberMask("FFF/BBB/UUUUP", "3FFF0BBBUUUUP"));

        public static readonly Bundesland SachsenAnhalt = Create("ST",
            TaxNumberMask("FFF/BBB/UUUUP", "3FFF0BBBUUUUP"));

        public static readonly Bundesland SchleswigHolstein = Create("SH",
            TaxNumberMask("FF/BBB/UUUUP", "21FF0BBBUUUUP"));

        public static readonly Bundesland Thueringen = Create("TH",
            TaxNumberMask("FFF/BBB/UUUUP", "4FFF0BBBUUUUP"));

        public static readonly Lst<Bundesland> All = Prelude.toList(all.Values);

        readonly MaskReplacer taxNumberReplacer;

        Bundesland(string value, MaskReplacer taxNumberReplacer) : base(value)
        {
            this.taxNumberReplacer = taxNumberReplacer;
        }

        public static Option<Bundesland> Parse(string code) =>
            all.TryGetValue(code, out var res) ? Prelude.Some(res) : Prelude.None;

        public bool IsTaxNumberValid(string value) =>
            this.taxNumberReplacer.IsValidInput(value);

        public Option<TaxNumber> CreateTaxNumber(string value)
        {
            if (!this.taxNumberReplacer.IsValidInput(value))
            {
                return Prelude.None;
            }
            
            var taxNumber = this.taxNumberReplacer.Replace(value);
            return TaxNumber.Create(taxNumber).AssertSome();
        }

        static Bundesland Create(string code, MaskReplacer taxNumberReplacer)
        {
            var bundesland = new Bundesland(code, taxNumberReplacer);
            all[code] = bundesland;
            return bundesland;
        }

        static MaskReplacer TaxNumberMask(string inputMask, string outputMask) =>
            new MaskReplacer(inputMask, outputMask);
    }
}