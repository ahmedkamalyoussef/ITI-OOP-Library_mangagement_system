using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Classes
{
    public class Library
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();

        public List<Book> Getbooks()
        {
            return books;
        }

        public List<Member> Getmember()
        {
            return members;
        }

        // ================= ADD BOOK =================
        public void AddBook(Book book)
        {
            foreach (Book b in books)
            {
                if (b.GetID() == book.GetID())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Book with ID {book.GetID()} already exists.");
                    Console.ResetColor();
                    return;
                }
            }

            books.Add(book);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Book '{book.GetTitle()}' added successfully.");
            Console.ResetColor();
        }

        // ================= REMOVE BOOK =================
        public bool removebook(Book book)
        {
            Book bookToRemove = null;
            Member memberToRemove = null;

            foreach (Book b in books)
            {
                if (b.GetID() == book.GetID())
                {
                    bookToRemove = b;
                    break;
                }
            }

            foreach (Member m in members)
            {
                if (bookToRemove != null && m.GetBorrowedBooks().Contains(bookToRemove))
                {
                    memberToRemove = m;
                    break;
                }
            }

            if (bookToRemove != null && bookToRemove._isAvailable)
            {
                books.Remove(bookToRemove);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Book '{bookToRemove.GetTitle()}' removed successfully.");
                Console.ResetColor();
                return true;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(
                $"Cannot remove book. It is borrowed by '{memberToRemove?.GetName()}'"
            );
            Console.ResetColor();

            return false;
        }

        // ================= ADD MEMBER =================
        public void AddMember(Member member)
        {
            foreach (Member m in members)
            {
                if (m.GetID() == member.GetID())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Member with ID {member.GetID()} already exists.");
                    Console.ResetColor();
                    return;
                }
            }

            members.Add(member);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Member '{member.GetName()}' added successfully.");
            Console.ResetColor();
        }

        // ================= REMOVE MEMBER =================
        public void removemember(Member member)
        {
            Member memberToRemove = null;
            Book bookToRemove = null;

            foreach (Member m in members)
            {
                if (m.GetID() == member.GetID())
                {
                    memberToRemove = m;
                    break;
                }
            }

            foreach (Book b in books)
            {
                if (memberToRemove != null && memberToRemove.GetBorrowedBooks().Contains(b))
                {
                    bookToRemove = b;
                    break;
                }
            }

            if (memberToRemove == null || memberToRemove.GetBorrowedBooks().Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    $"Cannot remove member '{memberToRemove?.GetName()}' because they borrowed '{bookToRemove?.GetTitle()}'."
                );
                Console.ResetColor();
                return;
            }

            members.Remove(memberToRemove);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Member '{memberToRemove.GetName()}' removed successfully.");
            Console.ResetColor();
        }

        // ================= BORROW BOOK =================
        public void BorrowBook(int memberId, int bookId)
        {
            Member member = null;
            Book book = null;

            foreach (Member m in members)
            {
                if (m.GetID() == memberId)
                {
                    member = m;
                    break;
                }
            }

            foreach (Book b in books)
            {
                if (b.GetID() == bookId)
                {
                    book = b;
                    break;
                }
            }

            if (member == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Member not found.");
                Console.ResetColor();
                return;
            }

            if (book == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Book not found.");
                Console.ResetColor();
                return;
            }

            if (!book._isAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Book is already borrowed.");
                Console.ResetColor();
                return;
            }

            book._isAvailable = false;
            member.AddBook(book);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{member.GetName()} borrowed '{book.GetTitle()}'.");
            Console.ResetColor();
        }

        // ================= RETURN BOOK =================
        public void ReturnBook(int memberId, int bookId)
        {
            Member member = null;
            Book book = null;

            foreach (Member m in members)
            {
                if (m.GetID() == memberId)
                {
                    member = m;
                    break;
                }
            }

            foreach (Book b in books)
            {
                if (b.GetID() == bookId)
                {
                    book = b;
                    break;
                }
            }

            if (member == null || book == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Member or Book not found.");
                Console.ResetColor();
                return;
            }

            if (!member.GetBorrowedBooks().Contains(book))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Member did not borrow this book.");
                Console.ResetColor();
                return;
            }

            book._isAvailable= true;
            member.RemoveBook(book);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book returned successfully.");
            Console.ResetColor();
        }
    }
}
