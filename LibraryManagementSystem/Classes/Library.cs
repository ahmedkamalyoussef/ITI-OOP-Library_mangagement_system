using System;

namespace LibraryManagementSystem.Classes;

public class Library
{
    private List<Book> books=new List<Book>();
    private List<Member> members=new List<Member>();

    public List<Book> Getbooks()
    {
        return books;
    }
    public List<Member> Getmember()
    {
        return members;
    }
    public void AddBook(Book book)
    {
        foreach (Book b in books)
        {
            if (b.GetID()==book.GetID())
            {
                Console.WriteLine($"book with ID {book.GetID()} already exists.");
                return;
            }
        }
        books.Add(book);
        Console.WriteLine("book is added successful.");
    }
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
            if (m.GetBorrowedBooks().Contains(bookToRemove))
            {
                memberToRemove = m;
                break;
            }
        }

        if (bookToRemove != null && bookToRemove.IsAvailable)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Book '{bookToRemove.GetTitle()}' removed successfully.");
            return true;
        }

        Console.WriteLine($"Book not found.&&Cannot remove a borrowed book{bookToRemove.GetTitle()} by {memberToRemove.GetName()}");
        return false;
    }

    public void AddMember(Member member)
    {
        foreach (Member m in members)
        {
            if (m.GetID()==member.GetID())
            {
                Console.WriteLine($"member with ID {member.GetID()} already exists.");
                return;
            }
        }
        members.Add(member);
        Console.WriteLine("member is added successful.");
    }
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
            if (memberToRemove.GetBorrowedBooks().Contains(b))
            {
                bookToRemove = b;
                break;
            }
        }

        //if (memberToRemove == null)
        //{
        //    Console.WriteLine("Member not found.");
        //    return;
        //}

        if (memberToRemove == null || memberToRemove.GetBorrowedBooks().Count > 0)
        {
            Console.WriteLine($"Cannot remove member '{memberToRemove.GetName()}' because they have borrowed  books {bookToRemove.GetTitle()}.");
            return;
        }

        members.Remove(memberToRemove);
        Console.WriteLine($"Member '{memberToRemove.GetName()}' removed successfully.");
    }
    
    //boorrow book
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
            Console.WriteLine("Member not found.");
            return;
        }

        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine("Book is already borrowed.");
            return;
        }

        book.IsAvailable=false;
        member.AddBook(book);

        Console.WriteLine($"{member.GetName()} borrowed '{book.GetTitle()}'");
    }
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
            Console.WriteLine("Member or Book not found.");
            return;
        }

        if (!member.GetBorrowedBooks().Contains(book))
        {
            Console.WriteLine("Member did not borrow this book.");
            return;
        }

        book.IsAvailable=true;
        member.RemoveBook(book);

        Console.WriteLine("Book returned successfully.");
    }

}
