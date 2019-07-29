namespace Krafteq.ElsterModel
{
    using System;

    public class KzFieldMeta
    {
        public string Description { get; }
        
        public int Number { get; }
        
        public KzFieldType Type { get; }

        public KzFieldMeta(int number, KzFieldType type, string description)
        {
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.Number = number;
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}