using System;

namespace Models
{
    public class User
    {
        public int UserId { get; set;}
        public string Name {get; set;}

        public List<Book> BorrowedBooks{ get; set; }

        public User ( int UserId , string Name )
        {
            this.UserId = UserId; 
            this.Name = Name;
            BorrowedBooks = new List<Book>();
        }

    public override string ToString()
    {
        return $"UserID: {UserId}, Name: {Name}, Borrowed Books: {BorrowedBooks}";
    }
        
    } 
}