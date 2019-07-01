namespace Krafteq.ElsterModel.Ustva
{
    using LanguageExt;

    /// <summary>
    /// Represents valid KzFields for Ustva report
    /// Can be created via UstvaKzFieldsForm.Validate method
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