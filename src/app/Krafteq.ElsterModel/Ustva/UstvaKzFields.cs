namespace Krafteq.ElsterModel.Ustva
{
    using LanguageExt;

    /// <summary>
    /// Represents valid KzFields for Ustva report
    /// Must be created via UstvaKzFieldsValidator.Validate
    /// </summary>
    public class UstvaKzFields
    {
        public Lst<KzField> Fields { get; }

        internal UstvaKzFields(Lst<KzField> fields)
        {
            this.Fields = fields;
        }
    }
}