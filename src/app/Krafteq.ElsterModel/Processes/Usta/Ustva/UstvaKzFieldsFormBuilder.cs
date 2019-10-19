namespace Krafteq.ElsterModel.Processes.Usta.Ustva
{
    using System;
    using LanguageExt;
    using static LanguageExt.Prelude;

    public class UstvaKzFieldsFormBuilder : KzFieldsFormBuilder
    {
        public UstvaKzFieldsFormBuilder()
        {
            this.F(10, KzFieldType.Boolean, "Specifies whether this report is correction");
            this.F(21, KzFieldType.MoneyIntUp, "Non-taxable other services");
            this.F(22, KzFieldType.Boolean, "Invoices are specially sorted");
            this.F(26, KzFieldType.Boolean, "Withdraw SEPA-Lastschriftmandant for this report");
            this.F(29, KzFieldType.Boolean, "Offsetting the refund amount desired");
            this.F(35, KzFieldType.MoneyIntDown, "Amount for other tax rates");
            this.F(36, KzFieldType.MoneyDown, "Tax Amout to Kz35");
            this.F(39, KzFieldType.UnsignedMoneyUp, "Deduction pre-payment amount for permanent extension");
            this.F(41, KzFieldType.MoneyIntDown, "Intra-Community deliveries (§ 4 no. 1 letter b UStG) to customers with VAT ID no");
            this.F(42, KzFieldType.MoneyIntDown, "Deliveries of the first customer (§ 25b (2) UStG) in intra-community triangular transactions");
            this.F(43, KzFieldType.MoneyIntDown, "Further tax-exempt sales with input tax deduction (eg export deliveries, sales according to § 4 Nos. 2 to 7 UStG)");
            this.F(44, KzFieldType.MoneyIntDown, "Intra-Community deliveries of new vehicles to customers without VAT ID.");
            this.F(45, KzFieldType.MoneyIntDown, "Other non-taxable sales (place of delivery not domestically)");
            this.F(46, KzFieldType.MoneyIntDown, "Steuerpflichtige sonstige Leistungen eines im übrigen Gemeinschaftsgebiet ansässigen Unternehmers (§ 13b Absatz 1 UStG)");
            this.F(47, KzFieldType.MoneyDown, "Tax Amount to Kz46");
            this.F(48, KzFieldType.MoneyIntDown, "Tax-free sales without input tax deduction according to § 4 Nos. 8 to 28 UStG");
            this.F(49, KzFieldType.MoneyIntDown, "Intra-Community deliveries of new vehicles outside a company (§ 2a UStG)");
            this.F(59, KzFieldType.MoneyUp, "Deduction of input tax for intra-Community deliveries of new vehicles outside a company (§ 2a UStG) as well as of small businesses within the meaning of § 19 Abs. 1 UStG (§ 15 Abs. 4a UStG)");
            this.F(60, KzFieldType.MoneyIntDown, "Other taxable transactions for which the beneficiary owes tax in accordance with §13b (5) UStG");
            this.F(61, KzFieldType.MoneyUp, "Input tax amounts from the intra-community acquisition of assets (§ 15 (1) sentence 1 No. 3 UStG)");
            this.F(62, KzFieldType.MoneyUp, "Incurred import sales tax (§ 15 para. 1 sentence 1 No. 2 UStG)");
            this.F(63, KzFieldType.MoneyUp, "Input tax amounts calculated according to general average rates (§§ 23 and 23a UStG)");
            this.F(64, KzFieldType.MoneyUp, "Correction of the amount of input tax (§ 15a UStG)");
            this.F(65, KzFieldType.MoneyDown, "Tax due to change of taxation type / tax form as well as after tax on taxed down payments due to tax rate increase");
            this.F(66, KzFieldType.MoneyUp, "Input tax amounts from invoices from other entrepreneurs (§ 15 (1) sentence 1 no. 1 UStG) and from intra-Community triangular transactions (§ 25b (5) UStG)");
            this.F(67, KzFieldType.MoneyUp, "Input tax amounts from services within the meaning of § 13b UStG (§ 15 para. 1 sentence 1 no. 4 UStG)");
            this.F(69, KzFieldType.MoneyDown, "Tax amounts incorrectly or unjustifiably shown in invoices (§14c UStG) and tax amounts owed pursuant to § 6a (4) sentence 2, § 17 (1) sentence 6, § 25b (2) UStG or by an outsourcer or warehouse keeper pursuant to § 13a (1) no. 6 UStG.");
            this.F(73, KzFieldType.MoneyIntDown, "Supplies of goods transferred by way of security and sales revenues which are not the GrEStG (Section 13b (2) No. 2 and 3 UStG)");
            this.F(74, KzFieldType.MoneyDown, "Tax Amount to Kz73");
            this.F(76, KzFieldType.MoneyIntDown, "Turnover for which a tax has to be paid in accordance with § 24 UStG (Sawmill products, Drinks and alcohol. Liquids (e.g. wine)");
            this.F(77, KzFieldType.MoneyIntDown, "Deliveries by agricultural and forestry enterprises to customers with a VAT ID number in accordance with $ 24 UStG (Value Added Tax Act)");
            this.F(80, KzFieldType.MoneyDown, "Tax Amount to Kz76");
            this.F(81, KzFieldType.MoneyIntDown, "Taxable amount at a tax rate of 19%.");
            this.F(83, KzFieldType.MoneyDown, "Remaining sales tax prepayment or remaining surplus");
            this.F(84, KzFieldType.MoneyIntDown, "Other benefits (section 13b(2)(4), (5)(b), (6) to (9) and (11) UStG)");
            this.F(85, KzFieldType.MoneyDown, "Tax Amount to Kz84");
            this.F(86, KzFieldType.MoneyIntDown, "Taxable amount at a tax rate of 7%.");
            this.F(89, KzFieldType.MoneyIntDown, "Intra-Community acquisitions at a tax rate of 19%.");
            this.F(91, KzFieldType.MoneyIntDown, "Tax-free intra-Community acquisitions according to §$ 4b and 25c VAT Act");
            this.F(93, KzFieldType.MoneyIntDown, "Intra-Community acquisitions at a tax rate of 7 %.");
            this.F(94, KzFieldType.MoneyIntDown, "Intra-Community acquisitions of new vehicles (§ 1b Abs. 2 und 3 StG) from suppliers without a VAT ID number at the general tax rate");
            this.F(95, KzFieldType.MoneyIntDown, "Intra-Community acquisitions at other tax rates");
            this.F(96, KzFieldType.MoneyDown, "Tax Amount to Kz94");
            this.F(98, KzFieldType.MoneyDown, "Tax Amount to Kz95");

            this.ValidationRules(83, KzFieldValidationRule.Required(), KzFieldValidationRule.Custom(ValidateKz83));
            this.ValidationRules(47, KzFieldValidationRule.LessThan(46));
            this.ValidationRules(53, KzFieldValidationRule.LessThan(52));
            this.ValidationRules(74, KzFieldValidationRule.LessThan(73));
            this.ValidationRules(79, KzFieldValidationRule.LessThan(78));
            this.ValidationRules(80, KzFieldValidationRule.LessThan(76));
            this.ValidationRules(85, KzFieldValidationRule.LessThan(84));
        }

        static Lst<KzFieldError> ValidateKz83(KzFieldSet fieldSet, int fieldNumber) =>
            fieldSet.GetValue(fieldNumber).Map(x => x.GetDecimalValue())
                .Map(fieldValue => CalculateKz83(fieldSet)
                    .Apply(
                        estimatedValue => Math.Abs(fieldValue - estimatedValue.Value) > 0.01m
                            ? List(KzFieldError.MustBeCloseToValue(estimatedValue.Value, 0.01m))
                            : Lst<KzFieldError>.Empty))
                .IfNone(Lst<KzFieldError>.Empty);

        static Money CalculateKz83(KzFieldSet fieldSet) =>
            new Kz83Calculator(fieldSet)
                .Calculate().IfFail(_ => throw new InvalidOperationException("Can't happen"));
    }
}