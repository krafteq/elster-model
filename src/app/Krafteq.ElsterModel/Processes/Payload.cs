namespace Krafteq.ElsterModel.Processes
{
    using System;
    using Krafteq.ElsterModel.Processes.Usta;

    /// <summary>
    /// Discriminated union with all supported payloads
    /// </summary>
    public class Payload
    {
        UstaPayload usta;

        /// <summary>
        /// UmsatzsteuerAnmeldung Process
        /// </summary>
        /// <param name="usta"></param>
        /// <returns></returns>
        public static Payload Usta(UstaPayload usta) => new Payload
            {usta = usta ?? throw new ArgumentNullException(nameof(usta))};

        public T Match<T>(Func<UstaPayload, T> whenUsta, Func<Payload, T> whenOther)
        {
            if (this.usta != null)
                return whenUsta(this.usta);
            
            return whenOther(this);
        }
    }
}