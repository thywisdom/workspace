using System;

namespace Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string Title , string Author , string ISBN )
        {
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Status: {(IsAvailable ? "Available" : "Borrowed")}";
        }

    }
}