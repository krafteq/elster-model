namespace Krafteq.ElsterModel
{
    using System.Collections.Generic;
    using System.Linq;
    using LanguageExt;
    
    using static LanguageExt.Prelude;

    public class KzFieldsForm
    {
        HashMap<int, KzFieldMeta> map;
        HashMap<int, KzFieldValidationRules> validationRulesMap;
        public Lst<KzFieldMeta> Fields { get; }
        public Lst<KzFieldValidationRules> ValidationRules { get; }

        public KzFieldsForm(Lst<KzFieldMeta> fields, Lst<KzFieldValidationRules> validationRules)
        {
            this.Fields = fields;
            this.ValidationRules = validationRules;
            this.validationRulesMap = toHashMap(validationRules.Map(x => (x.FieldNumber, x)));
            this.map = toHashMap(fields.Map(x => (x.Number, x)));
        }

        public KzFieldsFormValidationResult ValidateForm(IDictionary<int, object> values)
        {
            var fields = values.Map(x => this.GetFieldValue(x.Key, x.Value)
                    .Map(value => new KzField(x.Key, value))
                    .MapFail(err => new KzFieldValidationError(x.Key, List(err)))
                )
                .Apply(toList);

            var validFields = fields.SelectMany(f => f.SuccessAsEnumerable());
            var failedFields = fields.SelectMany(f => f.FailAsEnumerable());

            var fieldSet = new KzFieldSet(
                toHashSet(validFields));

            var failedValidationRules = this.ValidationRules
                .Map(x => (
                    x.FieldNumber,
                    errors: toList(x.Rules.SelectMany(rule => rule.Validate(fieldSet, x.FieldNumber)))
                    ))
                .Filter(x => x.errors.Any())
                .Map(x => new KzFieldValidationError(x.FieldNumber, x.errors));

            return new KzFieldsFormValidationResult(
                fieldSet,
                new KzFieldFormValidationError(toList(failedFields) + failedValidationRules));
        }

        Validation<KzFieldError, KzFieldValue> GetFieldValue(int number, object value) =>
            this.map.Find(number)
                .ToValidation(KzFieldError.UnknownField)
                .Bind(fieldMeta => fieldMeta.Type.CreateFieldValue(value));
    }
}