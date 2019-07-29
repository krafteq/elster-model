namespace Krafteq.ElsterModel.Ustva
{
    using System.Collections.Generic;
    using LanguageExt;

    /// <summary>
    /// Represents valid KzFields for Ustva report
    /// Can be created via UstvaKzFieldsForm.Validate method
    /// </summary>
    public class UstvaKzFields
    {
        public static readonly KzFieldsForm Form = new UstvaKzFieldsFormBuilder().Build();
        
        public KzFieldSet FieldSet { get; }

        UstvaKzFields(KzFieldSet fieldSet)
        {
            this.FieldSet = fieldSet;
        }

        public static Either<KzFieldFormValidationError, UstvaKzFields> Create(IDictionary<int, object> values)
        {
            var validationResult = Form.ValidateForm(values);

            return validationResult.IsValid
                ? (Either<KzFieldFormValidationError, UstvaKzFields>) new UstvaKzFields(validationResult.ValidFieldSet)
                : validationResult.ValidationError;
        }
    }
}