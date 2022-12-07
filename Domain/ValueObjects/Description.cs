namespace Domain.ValueObjects
{
    public class Description
    {
        public string Value { get; private set; }

        internal Description(string value)
        {
            Value = value;
        }    

        public static Description Create(string value)
        {
            return new Description(value);
        }
    }
}
