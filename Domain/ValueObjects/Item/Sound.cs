namespace Domain.ValueObjects.Item
{
    public class Sound : ValueObject
    {
        public string SoundPath { get; private set; }

        internal Sound(string soundPath)
        {
            SoundPath = soundPath;
        }

        public static Sound Create(string soundPath)
        {
            return new Sound(soundPath);
        }
    }
}
