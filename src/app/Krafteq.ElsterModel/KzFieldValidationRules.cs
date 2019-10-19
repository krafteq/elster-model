namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class KzFieldValidationRules
    {
        public int FieldNumber { get; }
        
        public Lst<KzFieldValidationRule> Rules { get; }

        public KzFieldValidationRules(int fieldNumber, Lst<KzFieldValidationRule> rules)
        {
            this.FieldNumber = fieldNumber;
            this.Rules = rules;
        }
    }
}