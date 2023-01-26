namespace Domain.ValueObjects.Item
{
    public class PrintDetails : ValueObject
    {
        public TimeSpan Time { get; private set; }
        public double Filament { get; private set; }
        public double Height { get; private set; }
        public bool HandPainted { get; private set; }
        public PrintDetails(TimeSpan time, double filament, double height, bool handPainted)
        {
            Time = time;
            Filament = filament;
            Height = height;
            HandPainted = handPainted;
        }

        public static PrintDetails Create(TimeSpan time, double filament, double height, bool handPainted)
        {
            return new PrintDetails(time, filament, height, handPainted);
        }
    }
}
