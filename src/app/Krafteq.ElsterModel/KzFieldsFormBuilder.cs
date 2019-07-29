namespace Krafteq.ElsterModel
{
    using System.Collections.Generic;
    using LanguageExt;
    
    using static LanguageExt.Prelude;

    public class KzFieldsFormBuilder
    {
        readonly List<KzFieldMeta> fields = new List<KzFieldMeta>();
        readonly List<KzFieldValidationRules> validationRules = new List<KzFieldValidationRules>();

        public KzFieldsForm Build()
        {
            return new KzFieldsForm(toList(this.fields), toList(this.validationRules));
        }

        protected void F(int number, KzFieldType type, string description)
        {
            this.fields.Add(new KzFieldMeta(number, type, description));
        }

        protected void ValidationRules(int number, params ValidationRule[] rules)
        {
            this.validationRules.Add(new KzFieldValidationRules(number, toList(rules)));
        }
    }
}