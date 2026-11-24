using System;

namespace GarbageCollectionHw
{
    public class Play : IDisposable
    {
        private string _title = String.Empty;
        private string _author = String.Empty;
        private string _genre = String.Empty;
        private int _year;

        public string Title
        {
            get { return _title; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _title = value;
                else
                    throw new ArgumentException("Title cannot be empty");
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _author = value;
                else
                    throw new ArgumentException("Author cannot be empty");
            }
        }

        public string Genre
        {
            get { return _genre; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _genre = value;
                else
                    throw new ArgumentException("Genre cannot be empty");
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (value > 0 && value <= 2026)
                    _year = value;
                else
                    throw new ArgumentException("Invalid year");
            }
        }

        public Play()
        {
            _title = "Unknown";
            _author = "Unknown";
            _genre = "Unknown";
            _year = 2000;
        }

        public Play(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Play: {Title}, Author: {Author}, Genre: {Genre}, Year: {Year}");
        }

        public override string ToString()
        {
            return $"Play: {Title} ({Year}), {Author} - {Genre}";
        }

        public void Dispose()
        {
            Console.WriteLine($"Dispose called for play: {Title}");
        }

        ~Play()
        {
            Console.WriteLine($"Finalizer called for play: {Title}");
        }
    }
}