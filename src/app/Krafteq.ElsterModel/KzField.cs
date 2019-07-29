namespace Krafteq.ElsterModel
{
    using System;

    public class KzField : IEquatable<KzField>
    {
        public int Number { get; }

        public KzFieldValue Value { get; }
        
        public KzField(int number, KzFieldValue value)
        {
            this.Number = number;
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool Equals(KzField other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.Number == other.Number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((KzField) obj);
        }

        public override int GetHashCode() => this.Number;

        public static bool operator ==(KzField left, KzField right) => Equals(left, right);

        public static bool operator !=(KzField left, KzField right) => !Equals(left, right);
    }
}