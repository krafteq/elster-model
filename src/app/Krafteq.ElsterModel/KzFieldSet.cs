namespace Krafteq.ElsterModel
{
    using LanguageExt;

    public class KzFieldSet
    {
        HashMap<int, KzFieldValue> map;

        public HashSet<KzField> Fields { get; }

        public KzFieldSet(HashSet<KzField> fields)
        {
            this.Fields = fields;
            this.map = Prelude.toHashMap(fields.Map(x => (x.Number, x.Value)));
        }

        public Option<KzFieldValue> GetValue(int number) =>
            this.map.Find(number);
    }
}