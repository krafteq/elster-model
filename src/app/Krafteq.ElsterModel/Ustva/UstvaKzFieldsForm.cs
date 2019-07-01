namespace Krafteq.ElsterModel.Ustva
{
    using System.Linq;
    using LanguageExt;
    
    using static LanguageExt.Prelude;

    public class UstvaKzFieldsForm
    {
        /// <summary>
        /// DE: Berichtigte Anmeldung
        /// EN: Correction 
        /// </summary>
        public bool Kz10 { get; set; }

        /// <summary>
        /// DE: Nicht steuerbare sonstige Leistungen
        /// EN: Non-taxable other services
        /// </summary>
        public Option<MoneyInt> Kz21 { get; set; }
        
        public bool Kz22 { get; set; }
        
        public bool Kz26 { get; set; }
        
        public bool Kz29 { get; set; }
        
        public Option<MoneyInt> Kz35 { get; set; }
        public Option<Money> Kz36 { get; set; }
        public Option<UnsignedMoney> Kz39 { get; set; }
        public Option<MoneyInt> Kz41 { get; set; }
        public Option<MoneyInt> Kz42 { get; set; }
        public Option<MoneyInt> Kz43 { get; set; }
        public Option<MoneyInt> Kz44 { get; set; }
        public Option<MoneyInt> Kz45 { get; set; }
        public Option<MoneyInt> Kz46 { get; set; }
        public Option<Money> Kz47 { get; set; }
        public Option<MoneyInt> Kz48 { get; set; }
        public Option<MoneyInt> Kz49 { get; set; }
        public Option<MoneyInt> Kz52 { get; set; }
        public Option<Money> Kz53 { get; set; }
        public Option<Money> Kz59 { get; set; }
        public Option<MoneyInt> Kz60 { get; set; }
        public Option<Money> Kz61 { get; set; }
        public Option<Money> Kz62 { get; set; }
        public Option<Money> Kz63 { get; set; }
        public Option<Money> Kz64 { get; set; }
        public Option<Money> Kz65 { get; set; }
        public Option<Money> Kz66 { get; set; }
        public Option<Money> Kz67 { get; set; }
        public Option<MoneyInt> Kz68 { get; set; }
        public Option<Money> Kz69 { get; set; }
        public Option<MoneyInt> Kz73 { get; set; }
        public Option<Money> Kz74 { get; set; }
        public Option<MoneyInt> Kz76 { get; set; }
        public Option<MoneyInt> Kz77 { get; set; }
        public Option<MoneyInt> Kz78 { get; set; }
        public Option<Money> Kz79 { get; set; }
        public Option<Money> Kz80 { get; set; }
        public Option<MoneyInt> Kz81 { get; set; }
        public Option<Money> Kz83 { get; set; }
        public Option<MoneyInt> Kz84 { get; set; }
        public Option<Money> Kz85 { get; set; }
        public Option<MoneyInt> Kz86 { get; set; }
        public Option<MoneyInt> Kz89 { get; set; }
        public Option<MoneyInt> Kz91 { get; set; }
        public Option<MoneyInt> Kz93 { get; set; }
        public Option<MoneyInt> Kz94 { get; set; }
        public Option<MoneyInt> Kz95 { get; set; }
        public Option<Money> Kz96 { get; set; }
        public Option<Money> Kz98 { get; set; }

        public Money CalculateKz83()
        {
            decimal V<T>(Option<T> t, decimal multiplier = 1m) where T : NewType<T, decimal> =>
                Unbox(t) * multiplier;

            return Money.RoundDown(
                    V(this.Kz81, 0.19m) +
                    V(this.Kz86, 0.07m) +
                    V(this.Kz36) +
                    V(this.Kz80) +
                    V(this.Kz96) +
                    V(this.Kz98) +
                    V(this.Kz89, 0.19m) +
                    V(this.Kz93, 0.07m) +
                    V(this.Kz85) +
                    V(this.Kz74) +
                    V(this.Kz79) +
                    V(this.Kz53) +
                    V(this.Kz47) +
                    V(this.Kz65) +
                    V(this.Kz66, -1) +
                    V(this.Kz61, -1) +
                    V(this.Kz62, -1) +
                    V(this.Kz67, -1) +
                    V(this.Kz63, -1) +
                    V(this.Kz64, -1) +
                    V(this.Kz59, -1) +
                    V(this.Kz69) +
                    V(this.Kz39, -1)
            );
        }

        static decimal Unbox<T>(Option<T> value)
            where T : NewType<T, decimal>
        {
            return value.Map(x => x.Value).IfNone(0m);
        }
    }
}