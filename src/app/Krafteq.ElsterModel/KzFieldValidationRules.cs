namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class KzFieldValidationRules
    {
        public int FieldNumber { get; }
        
        public Lst<ValidationRule> Rules { get; }

        public KzFieldValidationRules(int fieldNumber, Lst<ValidationRule> rules)
        {
            this.FieldNumber = fieldNumber;
            this.Rules = rules;
        }
    }
}