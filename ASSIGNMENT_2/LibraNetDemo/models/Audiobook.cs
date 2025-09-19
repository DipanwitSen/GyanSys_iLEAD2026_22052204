using System;

namespace LibraNetDemo.Models
{
    public class Audiobook : LibraryItem, IPlayable
    {
        public TimeSpan Duration { get; }

        public Audiobook(int id, string title, string author, TimeSpan duration)
            : base(id, title, author)
        {
            Duration = duration;
        }

        public void Play()
        {
            Console.WriteLine("Playing audiobook '{0}' (duration: {1}h {2}m)", Title, Duration.Hours, Duration.Minutes);
        }
    }
}
