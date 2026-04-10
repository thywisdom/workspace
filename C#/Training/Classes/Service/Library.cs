using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Models;
using Exceptions; 

namespace Service
{   
    public class Library{
        
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>();

        private void AddItem<T>(T item, List<T> list)
        {
            list.Add(item);
        }

        public void AddBook(Book book)
        {
            AddItem(book, books);
        }

        public void RegisterUser(User user)
        {
            AddItem(user, users);
        }

        public void DisplayBooks()
        {
            foreach(var book in books)
            {
                Console.WriteLine(book);
            }
        }
        public void DisplayUsers()
        {
            foreach(var user in users)
            {
                Console.WriteLine(user);
            }
        }

        public void BorrowBook(int userId, string isbn)
        {
            User selectedUser = null;
            Book selectedBook = null;

            foreach (User user in users)
            {
                if(user.UserId == userId)
                {
                    selectedUser = user;
                    break;
                }
            }

            foreach( Book book in books )
            {
                if(book.ISBN == isbn)
                {
                    selectedBook = book;
                    break;
                }
            }

            if(selectedBook == null)
            {
                throw new BookNotFoundException("Book Not Found!");
            }

            if (!selectedBook.IsAvailable)
            {
                Console.WriteLine("Book already borrowed.");
                return;
            }

            selectedBook.IsAvailable = false;
            selectedUser.BorrowedBooks.Add(selectedBook);

            Console.WriteLine("Book borrowed successfully.");
        }

        public void ReturnBook (int userId, string isbn)
        {
            foreach (User user in users)
            {
                if(user.UserId == userId)
                {
                    foreach (Book book in user.BorrowedBooks)
                    {
                        if(book.ISBN == isbn)
                        {
                            book.IsAvailable = true;
                            user.BorrowedBooks.Remove(book);

                            Console.WriteLine("Book returned successfully.");
                            return;
                        }
                    }
                }
            }
                    throw new BookNotFoundException("Book Not Found!");
        }


        public void SearchBook(string keyword)
        {
            bool found = false;

            foreach (Book book in books)
            {
                if(book.Title.ToLower().Contains(keyword.ToLower()) ||
                   book.Author.ToLower().Contains(keyword.ToLower()) ||
                   book.ISBN == keyword
                )
                {
                    Console.WriteLine(book);
                    found = true;
                }
            }

            if (!found)
              Console.WriteLine("No matching book found.");
        }
    } 
}