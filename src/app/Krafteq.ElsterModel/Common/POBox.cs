namespace Krafteq.ElsterModel.Common
{
    using LanguageExt;

    public class POBox
    {
        public static readonly POBox Empty = new POBox(Prelude.None, Prelude.None, Prelude.None);
        
        public Option<Box> Box { get; }
        public Option<Zip> Zip { get; }
        public Option<City> City { get; }

        public POBox(Option<Box> box, Option<Zip> zip, Option<City> city)
        {
            this.Box = box;
            this.Zip = zip;
            this.City = city;
        }
    }
}