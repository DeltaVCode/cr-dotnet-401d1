using System;

namespace Demo
{
    class Book : IEquatable<Book>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public bool Equals(Book other)
        {
            return other != null && other.Title == this.Title;
        }

        // Required stuff if you change equality
        public override bool Equals(object obj)
        {
            // as = treat obj as a Book, otherwise null
            return Equals(obj as Book);
        }

        public override int GetHashCode()
        {
            return Title == null ? 0 : Title.GetHashCode();
        }
    }
}
